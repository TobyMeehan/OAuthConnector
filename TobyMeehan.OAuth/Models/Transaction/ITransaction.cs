using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Interface representing a transaction.
    /// </summary>
    public interface ITransaction : IEntity
    {
        /// <summary>
        /// The application that sent the transaction.
        /// </summary>
        IApplication Sender { get; }

        /// <summary>
        /// The user the transaction was sent to.
        /// </summary>
        IUser User { get; }

        /// <summary>
        /// Additional detail about the transaction.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The amount the transaction changed the user's balance.
        /// </summary>
        int Amount { get; }
    }
}
