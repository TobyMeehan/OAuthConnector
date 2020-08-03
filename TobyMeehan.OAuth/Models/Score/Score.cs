using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    
    public class Score : ScoreBase, IScore
    {
        public Score(ScoreBase score)
        {
            Value = score.Value;
            User = new User(score.User);
        }

        public new IPartialUser User { get; set; }
    }
}
