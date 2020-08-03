using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a user.
    /// </summary>
    public interface IUser : IPartialUser
    {

        /// <summary>
        /// The user's balance.
        /// </summary>
        int Balance { get; }
    }
}
