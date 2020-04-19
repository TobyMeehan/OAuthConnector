using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Data;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a full user; with roles, transactions and balance.
    /// </summary>
    public class FullUser : User
    {
        [JsonProperty(PropertyName = "Roles")]
        private List<Role> _roles = new List<Role>();
        /// <summary>
        /// The user's roles.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Role> Roles => _roles.AsReadOnly();

        [JsonProperty(PropertyName = "Transactions")]
        private List<Transaction> _transactions = new List<Transaction>();
        /// <summary>
        /// The user's transactions.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        /// <summary>
        /// The user's balance.
        /// </summary>
        public int Balance { get; private set; }

        public override async Task<bool> TrySendTransactionAsync(string description, int amount)
        {
            bool success = await base.TrySendTransactionAsync(description, amount);

            if (success)
            {
                var transactionController = new TransactionController(_client);

                await transactionController.GetTransactions()
                    .OnOK<List<Transaction>>((result) =>
                    {
                        _transactions = result;
                        Balance += amount;
                    })
                    .SendAsync();
            }

            return success;
        }
    }
}
