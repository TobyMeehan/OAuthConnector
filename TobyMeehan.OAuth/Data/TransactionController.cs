using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Data
{
    class TransactionController
    {
        private readonly HttpClient _client;

        public TransactionController(HttpClient client)
        {
            _client = client;
        }

        public IHttpRequest GetTransactions()
        {
            return _client.Get($"{Config.ApiUrl}/users/@me/transactions");
        }

        public IHttpRequest SendTransaction(string description, int amount)
        {
            return _client.Post($"{Config.ApiUrl}/users/@me/transactions?allowNegative=false", new
            {
                description,
                amount
            });
        }
    }
}
