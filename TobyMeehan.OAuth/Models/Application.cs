using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing an OAuth application.
    /// </summary>
    public class Application : EntityBase
    {
        /// <summary>
        /// The name of the application.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the scoreboard for the application.
        /// </summary>
        /// <returns></returns>
        public async Task<Scoreboard> GetScoreboardAsync()
        {
            var scoreboardController = new ScoreboardController(_client);

            Scoreboard scoreboard = null;

            await scoreboardController.GetScoreboard()
                .OnOK<Scoreboard>((result) =>
                {
                    scoreboard = result;
                })
                .SendAsync();

            return scoreboard;
        }
    }
}
