﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class TokenController
    {
        private readonly HttpClient _client;

        public TokenController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetAccessTokenWithPkce(string clientId, string redirectUri, string codeVerifier, string authCode)
        {
            return _client.Post(Config.TokenUrl, new
            {
                grant_type = "authorization_code",
                code = authCode,
                redirect_uri = redirectUri,
                client_id = clientId,
                code_verifier = codeVerifier
            });
        }

        public IHttpRequest GetAccessTokenWithSecret(string clientId, string redirectUri, string secret, string authCode)
        {
            return _client.Post(Config.TokenUrl, new
            {
                grant_type = "authorization_code",
                code = authCode,
                redirect_uri = redirectUri,
                client_id = clientId,
                client_secret = secret
            });
        }
    }
}
