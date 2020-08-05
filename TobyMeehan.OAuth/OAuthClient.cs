﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;
using TobyMeehan.OAuth.Models;
using TobyMeehan.OAuth.Security;

namespace TobyMeehan.OAuth
{
    public class OAuthClient
    {
        private readonly ControllerService _controllerService;
        private readonly IAuthorizationService _authorizationService;
        private readonly HttpClient _httpClient;
        private readonly OAuthClientOptions _options;

        public OAuthClient(ControllerService controllerService, IAuthorizationService authorizationService, HttpClient httpClient, OAuthClientOptions options)
        {
            _controllerService = controllerService;
            _authorizationService = authorizationService;
            _httpClient = httpClient;
            _options = options;
        }

        /// <summary>
        /// Creates a new <see cref="OAuthClient"/> using the specified <see cref="OAuthClientOptions"/>.
        /// </summary>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static OAuthClient Create(Action<OAuthClientOptions> configureOptions = null) => OAuthClientBuilder.Create(configureOptions);

        /// <summary>
        /// The token for the current session.
        /// </summary>
        public Token Token { get; private set; }

        /// <summary>
        /// The current signed in user.
        /// </summary>
        public IUser User { get; private set; }

        /// <summary>
        /// The current application.
        /// </summary>
        public IApplication Application { get; private set; }

        /// <summary>
        /// The scoreboard for the current application.
        /// </summary>
        public IScoreboard Scoreboard { get; private set; }

        /// <summary>
        /// Collection of all downloads.
        /// </summary>
        public IEntityCollection<IDownload> Downloads { get; private set; }

        private async Task InitializeAsync(Token token, CancellationToken cancellationToken)
        {
            Token = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            User = await _controllerService.Users.GetAsync("@me", cancellationToken) as IUser;
            Application = await _controllerService.Applications.GetAsync("@me");
            Scoreboard = await Models.Scoreboard.CreateAsync(_controllerService.Scoreboard, cancellationToken);
            Downloads = await _controllerService.Downloads.GetAsync(cancellationToken);
        }

        /// <summary>
        /// Signs in the user using the PKCE OAuth extension.
        /// </summary>
        /// <param name="localhostPort">Port component of the localhost redirect URI.</param>
        /// <param name="scope">Space delimited string containing all the requested scopes for the session.</param>
        /// <param name="customSuccessFilePath">Path of custom HTML file to display when authorisation succeeds, relative to the path of the application.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        public async Task<bool> SignInAsync(int localhostPort, string scope = "identify", string customSuccessFilePath = null, CancellationToken cancellationToken = default)
        {
            string codeVerifier = Pkce.GenerateVerifier();
            string codeChallenge = Pkce.ChallengeFromVerifier(codeVerifier);
            string redirectUri = new Uri($"http://localhost:{localhostPort}").AbsoluteUri;

            Stream responseStream = null;

            if (customSuccessFilePath != null)
            {
                responseStream = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), customSuccessFilePath));
            }

            string code = await _authorizationService.GetAuthCodeAsync(_options.ClientId, redirectUri, scope, codeChallenge, responseStream);

            return await SignInAsync(redirectUri, code, codeVerifier, cancellationToken);
        }

        /// <summary>
        /// Signs in the user using the authorization code grant and a client secret.
        /// </summary>
        /// <param name="redirectUri">Redirect URI for this OAuth session.</param>
        /// <param name="authorizationCode">Authorization code aquired at the authorization endpoint.</param>
        /// <param name="codeVerifier">Optional code verifier if the PKCE extension was used.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        public async Task<bool> SignInAsync(string redirectUri, string authorizationCode, string codeVerifier = null, CancellationToken cancellationToken = default)
        {
            Token token = await _controllerService.Token.PostAsync(authorizationCode, redirectUri, _options.ClientId, _options.ClientSecret, codeVerifier, cancellationToken);

            await InitializeAsync(token, cancellationToken);

            return true;
        }

        /// <summary>
        /// Signs in the user using the refresh token grant.
        /// </summary>
        /// <param name="refreshToken">Refresh token for the OAuth session.</param>
        /// <param name="redirectUri">Redirect URI for the OAuth session.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        public async Task<bool> SignInAsync(string refreshToken, string redirectUri, CancellationToken cancellationToken = default)
        {
            Token token = await _controllerService.Token.PostAsync(refreshToken, redirectUri, _options.ClientId, cancellationToken);

            await InitializeAsync(token, cancellationToken);

            return true;
        }
    }
}
