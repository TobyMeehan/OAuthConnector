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

        public UserController(IHttp http)
        {
            _http = http;
        }

        public async Task<IEntityCollection<IUser>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<UserBase>>("/users", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<UserBase>> users)
            {
                return users.Data.ToEntityCollection<IUser, UserBase>(user => new User(user));
            }

            throw new Exception();
        }

        public async Task<IUser> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<UserBase>($"/users/{id}", cancellationToken);

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
                return new User(user.Data);
            }

            throw new Exception();
        }

        public async Task<IEntityCollection<IDownload>> GetDownloadsAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<DownloadBase>>($"/users/{id}/downloads", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<DownloadBase>> downloads)
            {
                return downloads.Data.ToEntityCollection<IDownload, DownloadBase>(download => new Download(download));
            }

            throw new Exception();
        }

        public async Task LeaveDownloadAsync(string id, string downloadId, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"/users/{id}/downloads/{downloadId}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }

                throw new ApiException(error);
            }
        }
    }
}
