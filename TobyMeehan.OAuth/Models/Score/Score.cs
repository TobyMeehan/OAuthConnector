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

        public static Task<Score> CreateAsync(ScoreBase @base, IScoreboardController controller)
        {
            return Task.FromResult(new Score(controller)
            {
                User = Models.User.CreatePartial(@base.User),
                Value = @base.Value
            });
        }

        public static async Task<IScoreCollection> CreateCollectionAsync(IEnumerable<ScoreBase> collection, IScoreboardController controller)
        {
            ScoreCollection scores = new ScoreCollection();

            foreach (var score in collection)
            {
                scores.Add(await CreateAsync(score, controller));
            }

            return scores;
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
