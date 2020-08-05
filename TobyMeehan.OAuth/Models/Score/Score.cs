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

        public static async Task<Score> CreateAsync(ScoreBase @base, IObjective objective, IScoreboardController controller, IUserController userController, CancellationToken cancellationToken)
        {
            return new Score(controller)
            {
                User = await Models.User.CreatePartialAsync(@base.User, userController, cancellationToken),
                Objective = objective,
                Value = @base.Value
            };
        }

        public static async Task<IScoreCollection> CreateCollectionAsync(IEnumerable<ScoreBase> collection, IObjective objective, IScoreboardController controller, IUserController userController, CancellationToken cancellationToken)
        {
            ScoreCollection scores = new ScoreCollection(controller, objective);

            foreach (var score in collection)
            {
                scores.Add(await CreateAsync(score, objective, controller, userController, cancellationToken));
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
