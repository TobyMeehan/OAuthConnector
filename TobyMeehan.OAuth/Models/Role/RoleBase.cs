using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class RoleBase : EntityBase
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
