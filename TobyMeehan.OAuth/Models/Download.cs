using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a download.
    /// </summary>
    public class Download : EntityBase
    {
        /// <summary>
        /// Title of the download.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Short description of the download.
        /// </summary>
        public string ShortDescription { get; }

        /// <summary>
        /// Long description of the download.
        /// </summary>
        public string LongDescription { get; }

    }
}
