using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class ScoreCollection : IScoreCollection
    {
        public ScoreCollection()
        {

        }

        public ScoreCollection(IEnumerable<IScore> collection)
        {
            _scores = collection.ToList();
        }

        private List<IScore> _scores = new List<IScore>();

        public IScore this[string userid] => _scores.Single(s => s.User.Id == userid);

        public void Add(IScore score) => _scores.Add(score);
        public void Remove(IScore score) => _scores.Remove(score);

        public IEnumerator<IScore> GetEnumerator()
        {
            return _scores.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
