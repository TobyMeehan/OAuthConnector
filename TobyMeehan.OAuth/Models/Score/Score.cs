using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    
    public class Score : ScoreBase, IScore
    {
        public new IObjective Objective { get; set; }
        public new IUser User { get; set; }
    }
}
