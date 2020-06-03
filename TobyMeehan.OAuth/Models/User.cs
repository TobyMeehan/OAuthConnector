using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a user.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The user's balance.
        /// </summary>
        public int Balance { get; private set; }

        /// <summary>
        /// The user's roles.
        /// </summary>
        public IEntityCollection<Role> Roles { get; private set; }

        /// <summary>
        /// The user's transactions.
        /// </summary>
        public IRepository<Transaction> Transactions { get; private set; }
    }
}
