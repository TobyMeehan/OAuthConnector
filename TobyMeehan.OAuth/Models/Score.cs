using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard score.
    /// </summary>
    public class Score
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
    }
}
