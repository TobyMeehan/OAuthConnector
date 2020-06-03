using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a transaction.
    /// </summary>
    public class Transaction : EntityBase
    {
        /// <summary>
        /// The application that sent the transaction.
        /// </summary>
        public Application Sender { get; private set; }

        /// <summary>
        /// The user the transaction was sent to.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Extra detail about the transaction.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The amount the transaction changed the user's balance.
        /// </summary>
        public int Amount { get; private set; }
    }
}
