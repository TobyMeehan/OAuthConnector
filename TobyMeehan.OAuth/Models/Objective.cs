using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard objective.
    /// </summary>
    public class Objective : EntityBase
    {
        /// <summary>
        /// Name of the objective.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <summary>
        /// Updates the user's score for this objective. This will not update any parent scoreboard object.
        /// </summary>
        /// <param name="score">New score to set for this objective.</param>
        /// <returns></returns>
        public async Task SetScoreAsync(int score)
        {
            var scoreboardController = new ScoreboardController(_client);

            await scoreboardController.UpdateScore(Id, score).SendAsync();
        }

        /// <summary>
        /// Deletes this objective. This will not update any parent scoreboard object.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync()
        {
            var scoreboardController = new ScoreboardController(_client);

            await scoreboardController.DeleteObjective(Id).SendAsync();                
        }
    }
}
