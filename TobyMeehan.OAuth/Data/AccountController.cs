using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class AccountController
    {
        private readonly HttpClient _client;

        public AccountController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetUser()
        {
            return _client.Get("https://api.tobymeehan.com/api/account");
        }
    }
}
