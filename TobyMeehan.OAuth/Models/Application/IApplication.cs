using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing an OAuth application.
    /// </summary>
    public interface IApplication : IEntity
    {
        /// <summary>
        /// The name of the application.
        /// </summary>
        string Name { get; }
    }
}
