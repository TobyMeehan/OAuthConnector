using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// The objective associated with the score.
        /// </summary>
        IObjective Objective { get; }

        /// <summary>
        /// Sets the score to the given value.
        /// </summary>
        /// <param name="value">Value to which the score should be set.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task SetAsync(int value, CancellationToken cancellationToken = default);
    }
}
