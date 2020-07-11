using System;
using System.Collections.Generic;
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
        }
    }
}
