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
            return _client.Get("https://api.tobymeehan.com/api/scoreboard");
        }

        public IHttpRequest CreateObjective(string name)
        {
            return _client.Post("https://api.tobymeehan.com/api/scoreboard/objective", name);
        }

        public IHttpRequest UpdateScore(string objective, int score)
        {
            return _client.Post("https://api.tobymeehan.com/api/scoreboard/score", new
            {
                objective,
                score
            });
        }

        public IHttpRequest DeleteObjective(string objective)
        {
            return _client.Delete($"https://api.tobymeehan.com/api/scoreboard/objective/{objective}");
        }
    }
}
