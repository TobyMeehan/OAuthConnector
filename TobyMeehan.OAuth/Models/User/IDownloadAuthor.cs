using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public interface IDownloadAuthor : IEntity
    {
        string Username { get; }

        IEntityCollection<IRole> Roles { get; }

        IDownload Download { get; }

        Task LeaveDownloadAsync(CancellationToken cancellationToken = default);
    }
}
