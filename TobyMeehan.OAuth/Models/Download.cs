using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public class Download : EntityBase
    {
        /// <summary>
        /// Title of the download.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Short description of the download.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Long description of the download.
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// The download's authors.
        /// </summary>
        public IRepository<DownloadAuthor> Authors { get; set; }
    }
}
