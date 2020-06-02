using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public interface IEntityCollection<T> : IEnumerable<T> where T : IEntity
    {
        T this[string id] { get; }
    }
}
