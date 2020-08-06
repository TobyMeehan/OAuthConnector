using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    
    public class Score : ScoreBase, IScore
    {
        private readonly IScoreboardController _controller;

        public Score(IScoreboardController controller)
        {
            _controller = controller;
        }

        public static Score Create(ScoreBase @base, IObjective objective, IScoreboardController controller)
        {
            return new Score(controller)
            {
                User = Models.User.Create(@base.User, null),
                Objective = objective,
                Value = @base.Value
            };
        }

        public new IPartialUser User { get; set; }

        public IObjective Objective { get; set; }

        public async Task SetAsync(int value, CancellationToken cancellationToken = default)
        {
            await _controller.PutScoreAsync(Objective.Id, User.Id, value, cancellationToken);

            Value = value;
        }
    }
}
