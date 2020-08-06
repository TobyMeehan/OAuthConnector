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

        /// <summary>
        /// A description of the application.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The URL of the application's icon image.
        /// </summary>
        string IconUrl { get; }

        /// <summary>
        /// The author of the application.
        /// </summary>
        IPartialUser Author { get; }

        /// <summary>
        /// The download connected to the application.
        /// </summary>
        IDownload Download { get; }
    }
}
