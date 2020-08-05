using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public interface IEntityCollection<T> : IEnumerable<T> where T : IEntity
    {
        /// <summary>
        /// Gets the entity with the given ID.
        /// </summary>
        /// <param name="id">ID of the required entity.</param>
        /// <returns></returns>
        T this[string id] { get; }
    }
}
