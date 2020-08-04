using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class EntityCollection<T> : IEntityCollection<T> where T : IEntity
    {
        public EntityCollection()
        {

        }

        public EntityCollection(IEnumerable<T> collection)
        {
            _items = collection.ToList();
        }

        private List<T> _items = new List<T>();

        public T this[string id] => _items.Single(x => x.Id == id);

        public void Add(T entity) => _items.Add(entity);

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class EnumerableExtensions
    {
        public static IEntityCollection<T> ToEntityCollection<T>(this IEnumerable<T> collection) where T : IEntity
        {
            return new EntityCollection<T>(collection);
        }

        public static IEntityCollection<T> ToEntityCollection<T, TSource>(this IEnumerable<TSource> collection, Func<TSource, T> map) where T : IEntity
        {
            return new EntityCollection<T>(collection.Select(map));
        }
    }
}
