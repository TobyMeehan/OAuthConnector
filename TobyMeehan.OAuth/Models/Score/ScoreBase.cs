using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class ScoreBase
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "user")]
        public UserBase User { get; set; }

    }
}
