using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class ScoreController : IScoreController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public ScoreController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Post(string objective, int score)
        {
            return _client.Post(_version.Url(Endpoint.Score), new
            {
                objective,
                score
            })
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
