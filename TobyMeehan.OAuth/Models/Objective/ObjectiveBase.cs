using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class ObjectiveBase : EntityBase
    {
        public string Name { get; set; }
        public List<ScoreBase> Scores { get; set; }
    }
}
