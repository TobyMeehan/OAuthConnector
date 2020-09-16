using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class ScoreboardController
    {
        private readonly HttpClient _client;

        public ScoreboardController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetScoreboard()
        {
            return _client.Get($"{Config.ApiUrl}/applications/@me/scoreboard");
        }

        public IHttpRequest CreateObjective(string name)
        {
            return _client.Post($"{Config.ApiUrl}/applications/@me/scoreboard", new { Name = name });
        }

        public IHttpRequest UpdateScore(string objective, int score, string user = "@me")
        {
            return _client.Post($"{Config.ApiUrl}/applications/@me/scoreboard/{objective}/users/{user}", new
            {
                objective,
                score
            });
        }

        public IHttpRequest DeleteObjective(string objective)
        {
            return _client.Delete($"{Config.ApiUrl}/scoreboard/{objective}");
        }
    }
}
