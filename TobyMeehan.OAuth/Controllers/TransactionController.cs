using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public class TransactionController : ITransactionController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public TransactionController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Get()
        {
            return _client.Get(_version.Url(Endpoint.Transaction))
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }

        public IHttpRequest Post(string description, int amount)
        {
            return _client.Post(_version.Url(Endpoint.Transaction), new
            {
                description,
                amount
            })
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
