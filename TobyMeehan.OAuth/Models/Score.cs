using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard score.
    /// </summary>
    public class Score : EntityBase
    {
        /// <summary>
        /// Objective the score belongs to.
        /// </summary>
        [JsonProperty]
        public Objective Objective { get; private set; }

        /// <summary>
        /// The user associated with the score.
        /// </summary>
        [JsonProperty]
        public User User { get; private set; }

        /// <summary>
        /// The value of the score.
        /// </summary>
        [JsonProperty]
        public int Value { get; private set; }

        /// <summary>
        /// Updates the score to the provided value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task SetAsync(int value)
        {
            var scoreboardController = new ScoreboardController(_client);

            await scoreboardController.UpdateScore(Objective.Id, value, User.Id).SendAsync();

            Value = value;
        }
    }
}
