using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public interface IEntity
    {
        /// <summary>
        /// The unique ID of the entity.
        /// </summary>
        string Id { get; }
    }
}
