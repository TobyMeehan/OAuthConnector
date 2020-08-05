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
    public class UserController : IUserController
    {
        private readonly IHttp _http;
        private readonly ControllerService _service;

        public UserController(IHttp http, ControllerService service)
        {
            _http = http;
            _service = service;
        }

        public async Task<IEntityCollection<IPartialUser>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<UserBase>>("api/users", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<UserBase>> users)
            {
                return await User.CreateCollectionAsync<IPartialUser>(users.Data, this, cancellationToken);
            }

            throw new Exception();
        }

        public async Task<IPartialUser> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<UserBase>($"api/users/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new ApiException(error);
            }

            if (result is IHttpResult<UserBase> user)
            {
                return await User.CreateAsync(user.Data, this, cancellationToken);
            }

            throw new Exception();
        }

        public async Task<IEntityCollection<IDownload>> GetDownloadsAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<DownloadBase>>($"api/users/{id}/downloads", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<DownloadBase>> downloads)
            {
                return await Download.CreateCollectionAsync(downloads.Data, _service.Downloads, cancellationToken);
            }

            throw new Exception();
        }

        public async Task LeaveDownloadAsync(string id, string downloadId, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"api/users/{id}/downloads/{downloadId}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }

                throw new ApiException(error);
            }
        }

        public async Task<IEntityCollection<ITransaction>> GetTransactionsAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<TransactionBase>>($"api/users/{id}/transactions", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<TransactionBase>> transaction)
            {
                return await Transaction.CreateCollectionAsync(transaction.Data, this, _service.Applications, cancellationToken);
            }

            throw new Exception();
        }

        public async Task<ITransaction> PostTransactionAsync(string id, string description, int amount, bool allowNegative, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<TransactionBase>($"api/users/{id}/transactions?allowNegative={allowNegative}", new
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
                return await Transaction.CreateAsync(transaction.Data, this, _service.Applications, cancellationToken);
            }

            throw new Exception();
        }
    }
}
