using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class DownloadController : IDownloadController
    {
        private readonly IHttp _http;
        private readonly ControllerService _service;

        public DownloadController(IHttp http, ControllerService service)
        {
            _http = http;
            _service = service;
        }

        public async Task<IEntityCollection<IDownload>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<DownloadBase>>("/api/downloads", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<DownloadBase>> downloads)
            {
                return await Download.CreateCollectionAsync(downloads.Data, this, cancellationToken);
            }

            throw new Exception();
        }

        public async Task<IDownload> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<DownloadBase>($"/api/downloads/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new ApiException(error);
            }

            if (result is IHttpResult<DownloadBase> download)
            {
                return await Download.CreateAsync(download.Data, this, cancellationToken);
            }

            throw new Exception();
        }

        public async Task<IDownload> Post(string title, string shortDescription, string longDescription, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<DownloadBase>("/api/downloads", new
            {
                Title = title,
                ShortDescription = shortDescription,
                LongDescription = longDescription
            }, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<DownloadBase> download)
            {
                return await Download.CreateAsync(download.Data, this, cancellationToken);
            }

            throw new Exception();
        }

        public async Task Delete(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"/api/downloads/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }
        }

        public async Task<IEntityCollection<IPartialUser>> GetAuthorsAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<UserBase>>($"/api/downloads/{id}/authors", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<UserBase>> users)
            {
                return await User.CreateCollectionAsync<IPartialUser>(users.Data, _service.Users, cancellationToken);
            }

            throw new Exception();
        }
    }
}
