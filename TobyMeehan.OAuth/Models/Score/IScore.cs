using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a scoreboard score.
    /// </summary>
    public interface IScore
    {
        /// <summary>
        /// The value of the score.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// The user associated with the score.
        /// </summary>
        IPartialUser User { get; }
    }
}
