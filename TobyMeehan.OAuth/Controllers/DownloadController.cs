using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class DownloadController : IDownloadController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public DownloadController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Get()
        {
            return _client.Get(_version.Url(Endpoint.Download))
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }

        public IHttpRequest Get(string id)
        {
            return _client.Get($"{_version.Url(Endpoint.Download)}/{id}")
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
