using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    
    public class Objective : ObjectiveBase, IObjective
    {
        public Objective(ObjectiveBase objective)
        {
            Id = objective.Id;
            Name = objective.Name;
            Scores = new ScoreCollection(objective.Scores.Select(s => new Score(s)));
        }

        public new IScoreCollection Scores { get; set; }
    }
}
