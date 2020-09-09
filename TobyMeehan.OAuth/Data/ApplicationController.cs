using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class ApplicationController
    {
        private readonly HttpClient _client;

        public ApplicationController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetApplication()
        {
            return _client.Get($"{Config.ApiUrl}/applications/@me");
        }
    }
}
