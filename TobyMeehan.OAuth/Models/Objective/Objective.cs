using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public static Objective Create(ObjectiveBase @base, IScoreCollection scores, IScoreboardController controller)
        {
            return new Objective(controller)
            {
                Id = @base.Id,
                Name = @base.Name,
                Scores = scores
            };
        }

        public new IScoreCollection Scores { get; set; }
    }
}
