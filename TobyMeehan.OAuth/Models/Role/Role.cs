using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    
    public class Role : RoleBase, IRole
    {
        public Role(RoleBase role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}
