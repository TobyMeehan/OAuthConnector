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

        public static async Task<Download> CreateAsync(DownloadBase @base, IDownloadController controller, CancellationToken cancellationToken)
        {
            var download = new Download(controller)
            {
                Id = @base.Id,
                Title = @base.Title,
                ShortDescription = @base.ShortDescription,
                LongDescription = @base.LongDescription,
                VersionString = @base.VersionString
            };

            download.Authors = await controller.GetAuthorsAsync(download, cancellationToken);

            return download;
        }

        public static async Task<IEntityCollection<IDownload>> CreateCollectionAsync(IEnumerable<DownloadBase> collection, IDownloadController controller, CancellationToken cancellationToken)
        {
            var entityCollection = new EntityCollection<IDownload>();

            foreach (var download in collection)
            {
                entityCollection.Add(await CreateAsync(download, controller, cancellationToken));
            }

            return entityCollection;
        }

        public new IEntityCollection<IDownloadAuthor> Authors { get; set; }
    }
}
