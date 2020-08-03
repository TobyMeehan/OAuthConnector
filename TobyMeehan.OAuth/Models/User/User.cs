using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public class User : UserBase, IUser
    {
        public User(UserBase user)
        {
            Id = user.Id;
            Username = user.Username;
            Balance = user.Balance;
            Roles = user.Roles.ToEntityCollection<IRole, RoleBase>(r => new Role(r));
        }

        public new IEntityCollection<IRole> Roles { get; set; }
    }
}
