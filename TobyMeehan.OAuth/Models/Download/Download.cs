using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    public class Download : DownloadBase, IDownload
    {
        private readonly IDownloadController _controller;

        public Download(IDownloadController controller)
        {
            _controller = controller;
        }

        public static Download Create(DownloadBase @base, IDownloadController controller)
        {
            return new Download(controller)
            {
                Id = @base.Id,
                Title = @base.Title,
                ShortDescription = @base.ShortDescription,
                LongDescription = @base.LongDescription,
                VersionString = @base.VersionString
            };
        }

        public new IEntityCollection<IPartialUser> Authors { get; set; }
    }
}
