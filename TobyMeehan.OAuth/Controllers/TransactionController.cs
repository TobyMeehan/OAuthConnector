using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class TransactionController : ITransactionController
    {
        private readonly IHttp _http;

        public TransactionController(IHttp http)
        {
            _http = http;
        }

        public async Task<IEntityCollection<ITransaction>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<TransactionBase>>($"/users/@me/transactions", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<TransactionBase>> transaction)
            {
                return transaction.Data.ToEntityCollection<ITransaction, TransactionBase>(x => new Transaction(x));
            }

            throw new Exception();
        }

        public async Task<ITransaction> PostAsync(string description, int amount, bool allowNegative, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<TransactionBase>($"/users/@me/transactions?allowNegative={allowNegative}", new
            {
                Description = description,
                Amount = amount
            }, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<TransactionBase> transaction)
            {
                return new Transaction(transaction.Data);
            }

            throw new Exception();
        }
    }
}
