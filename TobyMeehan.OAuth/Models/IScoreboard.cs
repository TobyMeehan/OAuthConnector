using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public interface IScoreboard
    {
        /// <summary>
        /// The objectives in the scoreboard.
        /// </summary>
        IEntityCollection<IObjective> Objectives { get; }


        /// <summary>
        /// Creates a new scoreboard objective with the given name.
        /// </summary>
        /// <param name="name">Name of the new objective.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task<IObjective> CreateObjectiveAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the provided objective from the scoreboard.
        /// </summary>
        /// <param name="objective">Objective to delete.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteObjectiveAsync(IObjective objective, CancellationToken cancellationToken = default);
    }
}
