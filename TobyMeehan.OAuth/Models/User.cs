using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a simple user.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; protected set; }

        /// <summary>
        /// Attempts to send a transaction to the user. Returns whether the transaction was successful.
        /// </summary>
        /// <param name="description">More detail about the transaction, for the user's benefit. For example, the area of the application the transaction was sent from.</param>
        /// <param name="amount">The amount to change the user's balance by.</param>
        /// <returns></returns>
        public virtual async Task<bool> TrySendTransactionAsync(string description, int amount)
        {
            var transactionController = new TransactionController(_client);

            bool success = false;

            await transactionController.SendTransaction(description, amount)
                .OnOK<object>((result) =>
                {
                    success = true;
                })
                .OnBadRequest<object>((result, statusCode, reasonPhrase) =>
                {
                    success = false;
                })
                .SendAsync();

            return success;
        }
    }
}
