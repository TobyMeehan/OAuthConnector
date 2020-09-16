using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
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

        public Scoreboard(IEnumerable<Objective> scoreboard) : this()
        {
            _objectives = scoreboard.ToList();

            foreach (var objective in scoreboard)
            {
                _scores.AddRange(objective.Scores);
            }
        }

        [JsonProperty(PropertyName = "Objectives")]
        private List<Objective> _objectives = new List<Objective>();
        /// <summary>
        /// All the objectives in the scoreboard.
        /// </summary>
        [JsonIgnore]
        public EntityCollection<Objective> Objectives => new EntityCollection<Objective>(_objectives);

        [JsonProperty(PropertyName = "Scores")]
        private List<Score> _scores = new List<Score>();
        /// <summary>
        /// The scores for each objective and user.
        /// </summary>
        [JsonIgnore]
        public ScoreCollection Scores => new ScoreCollection(_scores);

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
