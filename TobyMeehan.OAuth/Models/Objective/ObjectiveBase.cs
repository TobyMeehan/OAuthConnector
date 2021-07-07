using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class ObjectiveBase : EntityBase
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "scores")]
        public List<ScoreBase> Scores { get; set; }
    }
}
