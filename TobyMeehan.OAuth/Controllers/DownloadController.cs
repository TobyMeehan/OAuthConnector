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
            var result = await _http.GetAsync<List<DownloadBase>>("api/downloads", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<DownloadBase>> downloads)
            {
                EntityCollection<IDownload> collection = new EntityCollection<IDownload>();

                foreach (var download in downloads.Data)
                {
                    collection.Add(Download.Create(download, this));
                }

                return collection;
            }

            throw new Exception();
        }

        public async Task<IDownload> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<DownloadBase>($"api/downloads/{id}", cancellationToken);

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
                return Download.Create(download.Data, this);
            }

            throw new Exception();
        }

        public async Task<IDownload> Post(string title, string shortDescription, string longDescription, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<DownloadBase>("api/downloads", new
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
                return Download.Create(download.Data, this);
            }

            throw new Exception();
        }

        public async Task Delete(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"api/downloads/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }
        }

        public async Task<IEntityCollection<IPartialUser>> GetAuthorsAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<UserBase>>($"api/downloads/{id}/authors", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<UserBase>> users)
            {
                EntityCollection<IPartialUser> collection = new EntityCollection<IPartialUser>();

                foreach (var user in users.Data)
                {
                    collection.Add(User.Create(user, _service.Users));
                }

                return collection;
            }

            throw new Exception();
        }
    }
}
