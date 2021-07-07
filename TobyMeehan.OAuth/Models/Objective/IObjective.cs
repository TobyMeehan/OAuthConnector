using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a scoreboard objective.
    /// </summary>
    public interface IObjective : IEntity
    {
        /// <summary>
        /// The name of the objective.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The scores in the objective.
        /// </summary>
        IScoreCollection Scores { get; }
    }
}
