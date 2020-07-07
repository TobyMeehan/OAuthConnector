using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class TokenController : ITokenController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public TokenController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest PostPkce(string clientId, string redirectUri, string codeVerifier, string authCode)
        {
            return _client.Post(_version.Url(Endpoint.Token), new
            {
                grant_type = "authorization_code",
                code = authCode,
                redirect_uri = redirectUri,
                client_id = clientId,
                code_verifier = codeVerifier
            })
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }

        public IHttpRequest PostServer(string clientId, string redirectUri, string secret, string authCode)
        {
            return _client.Post(_version.Url(Endpoint.Token), new
            {
                grant_type = "authorization_code",
                code = authCode,
                redirect_uri = redirectUri,
                client_id = clientId,
                client_secret = secret
            })
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
