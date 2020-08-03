using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class UserBase : EntityBase
    {
        public string Username { get; set; }
        
        public int Balance { get; set; }

        public List<RoleBase> Roles { get; set; }
    }
}
