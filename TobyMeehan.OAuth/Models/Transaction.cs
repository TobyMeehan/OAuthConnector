using Newtonsoft.Json;
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
        /// The name of the application which sent the transation.
        /// </summary>
        [JsonProperty]
        public string Sender { get; }

        /// <summary>
        /// Extra detail about the transaction.
        /// </summary>
        [JsonProperty]
        public string Description { get; }

        /// <summary>
        /// The amount the transaction changed the user's balance.
        /// </summary>
        [JsonProperty]
        public int Amount { get; }
    }
}