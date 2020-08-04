using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a download.
    /// </summary>
    public interface IDownload : IEntity
    {
        /// <summary>
        /// Title of the download.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Short description of the download.
        /// </summary>
        string ShortDescription { get; }

        /// <summary>
        /// Long description of the download.
        /// </summary>
        string LongDescription { get; }

        /// <summary>
        /// The download's authors.
        /// </summary>
        IEntityCollection<IPartialUser> Authors { get; }
    }
}
