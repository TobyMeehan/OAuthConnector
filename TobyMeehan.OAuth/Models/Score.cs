using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Controllers;

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
        public Objective Objective { get; private set; }

        /// <summary>
        /// The user associated with the score.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// The value of the score.
        /// </summary>
        public int Value { get; private set; }
    }
}
