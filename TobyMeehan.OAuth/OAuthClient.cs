using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TobyMeehan.Http;
using TobyMeehan.OAuth.Data;
using TobyMeehan.OAuth.Models;
using TobyMeehan.OAuth.Security;

namespace TobyMeehan.OAuth
{
    public class OAuthClient
    {
        public OAuthClient()
        {
            HttpClient = new HttpClient();
            _timer.Elapsed += async (sender, e) => await RefreshSession();
        }

        internal static HttpClient HttpClient { get; set; }

        /// <summary>
        /// The current registered application.
        /// </summary>
        public Application Application { get; private set; }

        /// <summary>
        /// The current authenticated user.
        /// </summary>
        public AuthenticatedUser User { get; } = new AuthenticatedUser();

        /// <summary>
        /// The refresh token for the current session.
        /// </summary>
        public string RefreshToken => _token.RefreshToken;

        private JsonWebToken _token;

        private Timer _timer = new Timer(1000 * 60 * 10)
        {
            AutoReset = true,
            Enabled = true
        };
        private async Task RefreshSession()
        {
            await SignInAsync(RefreshToken);
        }

        /// <summary>
        /// Signs in the user using the PKCE OAuth extension, and obtains an access token for use with further requests to the API.
        /// </summary>
        /// <param name="clientId">Client ID of this application.</param>
        /// <param name="port">Port on localhost to expect a request containing an authorization code. This must form the same URL as the redirect URI set for this application.</param>
        /// <param name="customSuccessFilePath">Path of custom HTML file to display when authorisation succeeds, relative to the path of the application.</param>
        /// <returns></returns>
        public async Task SignInAsync(string clientId, int port, string customSuccessFilePath = null)
        {
            string codeVerifier = Pkce.GenerateVerifier();
            string codeChallenge = Pkce.ChallengeFromVerifier(codeVerifier);

            string redirectUri = $"http://localhost:{port}/";

            Stream responseStream = null;

            if (customSuccessFilePath != null)
            {
                responseStream = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), customSuccessFilePath));
            }

            var authController = new AuthorizationController();

            string authCode = await authController.GetAuthCode(clientId, redirectUri, codeChallenge, responseStream);

            var tokenController = new TokenController(HttpClient);

            await SignInAsync(tokenController.GetAccessTokenWithPkce(clientId, redirectUri, codeVerifier, authCode));
        }

        /// <summary>
        /// Signs in the user using the traditional authorization code grant with a client secret. This method should only be used with server apps and requires an already obtained auth code.
        /// </summary>
        /// <param name="clientId">Client ID of this application.</param>
        /// <param name="redirectUri">Redirect URI of this application.</param>
        /// <param name="secret">Client secret of this application.</param>
        /// <param name="authCode">Authorization code which has already been acquired.</param>
        /// <returns></returns>
        public async Task SignInAsync(string clientId, string redirectUri, string secret, string authCode)
        {
            var tokenController = new TokenController(HttpClient);

            await SignInAsync(tokenController.GetAccessTokenWithSecret(clientId, redirectUri, secret, authCode));
        }

        /// <summary>
        /// Signs in the user using a refresh token so that the user does not need to authorise again. This method is called regularly while the application is running to keep the user signed in.
        /// </summary>
        /// <param name="refreshToken">Refresh token to validate session.</param>
        /// <returns></returns>
        public async Task SignInAsync(string refreshToken)
        {
            var tokenController = new TokenController(HttpClient);

            await SignInAsync(tokenController.GetAccessTokenWithRefresh(refreshToken, Application.Id));
        }

        private async Task SignInAsync(IHttpRequest tokenRequest)
        {
            await tokenRequest.OnOK<JsonWebToken>((token) =>
            {
                _token = token;
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_token.TokenType, _token.AccessToken);
            })
            .OnBadRequest<dynamic>((obj, statusCode) =>
            {
                throw new Exception();
            })
            .SendAsync();

            var accountController = new AccountController(HttpClient);

            await accountController.GetUser()
                .OnOK<User>((user) =>
                {
                    User.SignIn(user.Id, user.Username, _token.AccessToken);
                })
                .SendAsync();

            var applicationController = new ApplicationController(HttpClient);

            await applicationController.GetApplication()
                .OnOK<Application>((app) =>
                {
                    Application = app;
                })
                .SendAsync();
        }

        /// <summary>
        /// Signs out the current signed in user.
        /// </summary>
        public void SignOut()
        {
            _token = null;
            User.SignOut();
        }

        /// <summary>
        /// Gets the full information on the current signed in user.
        /// </summary>
        /// <returns></returns>
        public async Task<FullUser> GetSignedInUserAsync()
        {
            if (!User.IsSignedIn)
            {
                return null;
            }

            FullUser user = null;

            var accountController = new AccountController(HttpClient);

            await accountController.GetUser()
                .OnOK<FullUser>((result) =>
                {
                    user = result;
                })
                .SendAsync();

            return user;
        }
    }
}
