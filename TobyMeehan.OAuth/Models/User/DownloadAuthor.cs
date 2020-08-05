using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    public class DownloadAuthor : UserBase, IDownloadAuthor
    {
        private readonly IUserController _controller;

        public DownloadAuthor(IUserController controller)
        {
            _controller = controller;
        }

        public static async Task<DownloadAuthor> CreateAsync(UserBase @base, IDownload download, IUserController controller, CancellationToken cancellationToken)
        {
            return new DownloadAuthor(controller)
            {
                Id = @base.Id,
                Username = @base.Username,
                Roles = @base.Roles.ToEntityCollection<IRole, RoleBase>(x => new Role(x)),
                Download = download
            };
        }

        public static async Task<IEntityCollection<IDownloadAuthor>> CreateCollectionAsync(IEnumerable<UserBase> collection, IDownload download, IUserController controller, CancellationToken cancellationToken)
        {
            EntityCollection<IDownloadAuthor> authors = new EntityCollection<IDownloadAuthor>();

            foreach (var author in collection)
            {
                authors.Add(await CreateAsync(author, download, controller, cancellationToken));
            }

            return authors;
        }

        public Task LeaveDownloadAsync(CancellationToken cancellationToken = default)
        {
            return _controller.LeaveDownloadAsync(Id, Download.Id, cancellationToken);
        }

        public new IEntityCollection<IRole> Roles { get; set; }

        public IDownload Download { get; set; }
    }
}
