using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class DownloadController
    {
        private readonly HttpClient _client;

        public DownloadController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetDownloads()
        {
            return _client.Get($"{Config.ApiUrl}/download");
        }

        public IHttpRequest GetDownload(string id)
        {
            return _client.Get($"{Config.ApiUrl}/download/{id}");
        }
    }
}
