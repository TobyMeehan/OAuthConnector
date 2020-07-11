using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
