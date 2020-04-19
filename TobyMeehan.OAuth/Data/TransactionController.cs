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
            return _client.Get($"{Config.ApiUrl}/transaction");
        }

        public IHttpRequest SendTransaction(string description, int amount)
        {
            return _client.Post($"{Config.ApiUrl}/transaction", new
            {
                description,
                amount
            });
        }
    }
}
