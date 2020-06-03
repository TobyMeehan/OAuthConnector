using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard objective.
    /// </summary>
    public class Objective : EntityBase
    {
        /// <summary>
        /// The name of the objective.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// All scores for this objective.
        /// </summary>
        public IEntityCollection<Score> Scores { get; private set; }
    }
}
