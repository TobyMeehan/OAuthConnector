using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public interface IPartialUser : IEntity
    {
        string Username { get; }
        
        IEntityCollection<IRole> Roles { get; }
    }
}
