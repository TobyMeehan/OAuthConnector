using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class UserBase : EntityBase
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        
        [DataMember(Name = "balance")]
        public int Balance { get; set; }

        [DataMember(Name = "roles")]
        public List<RoleBase> Roles { get; set; }
    }
}
