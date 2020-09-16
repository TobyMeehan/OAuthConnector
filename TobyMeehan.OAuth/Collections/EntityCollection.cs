﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class EntityCollection<T> : IEnumerable<T> where T : EntityBase
    {
        public EntityCollection() { }

        public EntityCollection(IEnumerable<T> items)
        {
            _items = items.ToList();
        }

        private List<T> _items = new List<T>();

        public T this[string id] => _items.Single(e => e.Id == id);

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
