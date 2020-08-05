using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class TokenController : ITokenController
    {
        private readonly IHttp _http;

        public TokenController(IHttp http)
        {
            _http = http;
        }

        public async Task<Token> PostAsync(string authorizationCode, string redirectUri, string clientId, string clientSecret = null, string codeVerifier = null, CancellationToken cancellationToken = default)
        {
            Dictionary<string, string> form = new Dictionary<string, string>
            {
                {"grant_type", "authorization_code" },
                {"code", authorizationCode },
                {"redirect_uri", redirectUri },
                {"client_id", clientId },
                {"client_secret", clientSecret },
                {"code_verifier", codeVerifier }
            };

            var result = await _http.PostAsync<JsonWebToken>("oauth/token", form, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new AuthorizationFailedException("Error Getting Access Token", error.Message);
            }

            if (result is IHttpResult<JsonWebToken> token)
            {
                return new Token(token.Data.access_token, token.Data.token_type, token.Data.expires_in, token.Data.refresh_token);
            }

            throw new Exception();
        }

        public async Task<Token> PostAsync(string refreshToken, string redirectUri, string clientId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, string> form = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token" },
                {"redirect_uri", redirectUri },
                {"client_id", clientId },
                {"refresh_token", refreshToken }
            };

            var result = await _http.PostAsync<JsonWebToken>("oauth/token", form, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new AuthorizationFailedException("Error Refreshing Token", error.Message);
            }

            if (result is IHttpResult<JsonWebToken> token)
            {
                return new Token(token.Data.access_token, token.Data.token_type, token.Data.expires_in, token.Data.refresh_token);
            }

            throw new Exception();
        }
    }
}
