using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public class Download : DownloadBase, IDownload
    {
        public Download(DownloadBase download)
        {
            Id = download.Id;
            Title = download.Title;
            ShortDescription = download.ShortDescription;
            LongDescription = download.LongDescription;
        }
    }
}
