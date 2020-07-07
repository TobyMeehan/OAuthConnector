using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class ApplicationController : IApplicationController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public ApplicationController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Get()
        {
            return _client.Get(_version.Url(Endpoint.Application))
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
