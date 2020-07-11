using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard score.
    /// </summary>
    public interface IScore : IEntity
    {
        /// <summary>
        /// The value of the score.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Objective the score belongs to.
        /// </summary>
        IObjective Objective { get; }

        /// <summary>
        /// The user associated with the score.
        /// </summary>
        IUser User { get; }
    }
}
