using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class ObjectiveController : IObjectiveController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public ObjectiveController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Post(string name)
        {
            return _client.Post(_version.Url(Endpoint.Objective), name)
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }

        public IHttpRequest Delete(string id)
        {
            return _client.Delete($"{_version.Url(Endpoint.Objective)}/{id}")
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
