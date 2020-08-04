using System;
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
    public class OAuthClient : IOAuthClient
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

        public static OAuthClient Create(Action<OAuthClientOptions> configureOptions = null) => OAuthClientBuilder.Create(configureOptions);

        public Token Token { get; private set; }

        public IUser User { get; private set; }

        public IApplication Application { get; private set; }

        public IScoreboard Scoreboard { get; private set; }

        public IEntityCollection<IDownload> Downloads { get; private set; }

        private async Task InitializeAsync(Token token, CancellationToken cancellationToken)
        {
            Token = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            User = await _controllerService.Users.GetAsync("@me", cancellationToken);
            Application = await _controllerService.Applications.GetAsync("@me");
            Scoreboard = await Models.Scoreboard.CreateAsync(_controllerService.Scoreboard, cancellationToken);
            Downloads = await _controllerService.Downloads.GetAsync(cancellationToken);
        }

        public async Task<bool> SignInAsync(int localhostPort, string customSuccessFilePath = null, CancellationToken cancellationToken = default)
        {
            string codeVerifier = Pkce.GenerateVerifier();
            string codeChallenge = Pkce.ChallengeFromVerifier(codeVerifier);
            string redirectUri = new Uri($"http://localhost:{localhostPort}").AbsoluteUri;

            Stream responseStream = null;

            if (customSuccessFilePath != null)
            {
                responseStream = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), customSuccessFilePath));
            }

            string code = await _authorizationService.GetAuthCodeAsync(_options.ClientId, redirectUri, codeChallenge, responseStream);

            return await SignInAsync(redirectUri, code, codeVerifier, cancellationToken);
        }

        public async Task<bool> SignInAsync(string redirectUri, string authorizationCode, string codeVerifier = null, CancellationToken cancellationToken = default)
        {
            Token token = await _controllerService.Token.PostAsync(authorizationCode, redirectUri, _options.ClientId, _options.ClientSecret, codeVerifier, cancellationToken);

            await InitializeAsync(token, cancellationToken);

            return true;
        }

        public async Task<bool> SignInAsync(string refreshToken, string redirectUri, CancellationToken cancellationToken = default)
        {
            Token token = await _controllerService.Token.PostAsync(refreshToken, redirectUri, _options.ClientId, cancellationToken);

            await InitializeAsync(token, cancellationToken);

            return true;
        }
    }
}
