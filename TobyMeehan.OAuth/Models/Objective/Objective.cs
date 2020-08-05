using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    
    public class Objective : ObjectiveBase, IObjective
    {
        private readonly IScoreboardController _controller;

        public Objective(IScoreboardController controller)
        {
            _controller = controller;
        }

        public static async Task<Objective> CreateAsync(ObjectiveBase @base, IScoreboardController controller, IUserController userController, CancellationToken cancellationToken)
        {
            return new Objective(controller)
            {
                Id = @base.Id,
                Name = @base.Name,
                Scores = await Score.CreateCollectionAsync(@base.Scores, controller, userController, cancellationToken)
            };
        }

        public static async Task<IEntityCollection<IObjective>> CreateCollectionAsync(IEnumerable<ObjectiveBase> collection, IScoreboardController controller, IUserController userController, CancellationToken cancellationToken)
        {
            EntityCollection<IObjective> objectives = new EntityCollection<IObjective>();

            foreach (var objective in collection)
            {
                objectives.Add(await CreateAsync(objective, controller, userController, cancellationToken));
            }

            return objectives;
        }

        public new IScoreCollection Scores { get; set; }
    }
}
