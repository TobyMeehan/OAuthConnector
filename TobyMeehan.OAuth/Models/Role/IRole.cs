using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a user role.
    /// </summary>
    public interface IRole : IEntity
    {
        /// <summary>
        /// Name of the role.
        /// </summary>
        string Name { get; }
    }
}
