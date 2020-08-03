using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class ScoreBase
    {
        public int Value { get; set; }
        public UserBase User { get; set; }

    }
}
