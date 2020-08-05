using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a partial user, with no balance or transactions.
    /// </summary>
    public interface IPartialUser : IEntity
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        string Username { get; }
        
        /// <summary>
        /// The user's roles.
        /// </summary>
        IEntityCollection<IRole> Roles { get; }

        /// <summary>
        /// The downloads of which the user is an author.
        /// </summary>
        IEntityCollection<IDownload> Downloads { get; }
    }
}
