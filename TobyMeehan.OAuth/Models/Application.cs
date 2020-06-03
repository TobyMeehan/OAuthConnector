using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

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
        public string Name { get; private set; }

        /// <summary>
        /// The application's scoreboard.
        /// </summary>
        public IEntityCollection<Objective> Scoreboard { get; private set; }
    }
}
