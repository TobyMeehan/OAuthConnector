using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    public class Scoreboard : IScoreboard
    {
        private readonly IScoreboardController _controller;

        public Scoreboard(IScoreboardController controller)
        {
            _controller = controller;
        }

        public static async Task<Scoreboard> CreateAsync(IScoreboardController controller, CancellationToken cancellationToken)
        {
            return new Scoreboard(controller)
            {
                Objectives = await controller.GetAsync(cancellationToken)
            };
        }

        public async Task<IObjective> CreateObjectiveAsync(string name, CancellationToken cancellationToken = default)
        {
            var objective = await _controller.PostAsync(name, cancellationToken);

            (Objectives as EntityCollection<IObjective>)?.Add(objective);

            return objective;
        }

        public async Task DeleteObjectiveAsync(IObjective objective, CancellationToken cancellationToken = default)
        {
            await _controller.DeleteAsync(objective.Id, cancellationToken);

            (Objectives as EntityCollection<IObjective>)?.Remove(objective);
        }

        public IEntityCollection<IObjective> Objectives { get; set; }
    }
}
