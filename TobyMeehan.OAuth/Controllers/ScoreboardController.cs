using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class ScoreboardController : IScoreboardController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public ScoreboardController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IObjectiveController Objectives { get; set; }
        public IScoreController Scores { get; set; }

        public IHttpRequest Get()
        {
            return _client.Get(_version.Url(Endpoint.Scoreboard))
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
