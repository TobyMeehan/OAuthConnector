using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        /// <summary>
        /// The user's transaction history.
        /// </summary>
        IEntityCollection<ITransaction> Transactions { get; }

        /// <summary>
        /// Attempts to send a transaction to the user. Returns whether the transaction was successful.
        /// </summary>
        /// <param name="description">More detail about the transaction, for the user's benefit. For example, the area of the application the transaction was sent from.</param>
        /// <param name="amount">The amount to change the user's balance by.</param>
        /// <param name="allowNegative">Whether the user's balance should be allowed to go below 0.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task<bool> TrySendTransactionAsync(string description, int amount, bool allowNegative = false, CancellationToken cancellationToken = default);
    }
}
