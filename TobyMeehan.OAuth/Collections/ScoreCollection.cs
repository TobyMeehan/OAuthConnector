using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class ScoreCollection : IEnumerable<Score>
    {
        public ScoreCollection() { }

        public ScoreCollection(IEnumerable<Score> items)
        {
            _items = items.ToList();
        }

        private List<Score> _items = new List<Score>();

        public Score this[string userId] => _items.Single(s => s.User.Id == userId);

        public IEnumerator<Score> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
