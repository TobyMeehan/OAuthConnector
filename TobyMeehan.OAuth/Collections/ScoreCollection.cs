using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Controllers;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class ScoreCollection : IScoreCollection
    {
        public ScoreCollection(IScoreboardController controller, IObjective objective)
        {
            _controller = controller;
            _objective = objective;
        }

        public ScoreCollection(IEnumerable<IScore> collection, IObjective objective, IScoreboardController controller)
        {
            _scores = collection.ToList();
            _objective = objective;
            _controller = controller;
        }

        private List<IScore> _scores = new List<IScore>();
        private readonly IScoreboardController _controller;
        private readonly IObjective _objective;

        public IScore this[IUser user]
        {
            get
            {
                var score = _scores.SingleOrDefault(x => x.User.Id == user.Id);

                if (score != null)
                    return score;

                return new Score(_controller)
                {
                    User = user,
                    Value = 0,
                    Objective = _objective
                };
            }
        }

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
