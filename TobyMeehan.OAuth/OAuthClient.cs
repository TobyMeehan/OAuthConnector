using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
        }

        internal static HttpClient HttpClient { get; set; }

        public Application Application { get; }
        public AuthenticatedUser User { get; } = new AuthenticatedUser();

        private JsonWebToken _token;

        /// <summary>
        /// Signs in the user using the PKCE OAuth extension, and obtains an access token for use with further requests to the API.
        /// </summary>
        /// <param name="clientId">Client ID of this application.</param>
        /// <param name="port">Port on localhost to expect a request containing an authorization code. This must form the same URL as the redirect URI set for this application.</param>
        /// <returns></returns>
        public async Task SignInAsync(string clientId, int port)
        {
            string codeVerifier = Pkce.GenerateVerifier();
            string codeChallenge = Pkce.ChallengeFromVerifier(codeVerifier);

            string redirectUri = $"http://localhost:{port}/";

            var authController = new AuthorizationController();

            string authCode = await authController.GetAuthCode(clientId, redirectUri, codeChallenge);

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

        private async Task SignInAsync(IHttpRequest tokenRequest)
        {
            await tokenRequest.OnOK<JsonWebToken>((token) =>
            {
                _token = token;
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_token.TokenType, _token.AccessToken);
            })
            .SendAsync();

            var accountController = new AccountController(HttpClient);

            await accountController.GetUser()
                .OnOK<User>((user) =>
                {
                    User.SignIn(user.Id, user.Username, _token.AccessToken);
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
