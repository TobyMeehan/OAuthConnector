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
        /// <summary>
        /// The username of the author.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The user's roles.
        /// </summary>
        IEntityCollection<IRole> Roles { get; }

        /// <summary>
        /// The download of which the user is an author.
        /// </summary>
        IDownload Download { get; }

        /// <summary>
        /// Leaves the download as an author, provided the user has the downloads scope in the current session.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task LeaveDownloadAsync(CancellationToken cancellationToken = default);
    }
}
