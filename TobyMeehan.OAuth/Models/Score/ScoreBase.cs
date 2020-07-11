using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class ScoreBase : EntityBase
    {
        public int Value { get; set; }
        public ObjectiveBase Objective { get; set; }
        public UserBase User { get; set; }

    }
}
