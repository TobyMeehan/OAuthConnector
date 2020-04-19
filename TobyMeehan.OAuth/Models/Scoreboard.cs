using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing an application scoreboard.
    /// </summary>
    public class Scoreboard
    {
        private readonly HttpClient _client;

        public Scoreboard()
        {
            _client = OAuthClient.HttpClient;
        }

        [JsonProperty(PropertyName = "Objectives")]
        private List<Objective> _objectives = new List<Objective>();
        /// <summary>
        /// All the objectives in the scoreboard.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Objective> Objectives => _objectives.AsReadOnly();

        [JsonProperty(PropertyName = "Scores")]
        private List<Score> _scores = new List<Score>();
        /// <summary>
        /// The scores for each objective and user.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Score> Scores => _scores.AsReadOnly(); 

        /// <summary>
        /// Creates a new objective with the specified name.
        /// </summary>
        /// <param name="name">Name of the new objective.</param>
        /// <returns></returns>
        public async Task CreateObjectiveAsync(string name)
        {
            var scoreboardController = new ScoreboardController(_client);

            await scoreboardController.CreateObjective(name)
                .OnOK<Objective>((result) =>
                {
                    _objectives.Add(result);
                })
                .SendAsync();
        }
    }
}
