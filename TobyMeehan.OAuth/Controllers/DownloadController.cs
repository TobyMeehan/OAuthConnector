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

        public DownloadController(IHttp http)
        {
            _http = http;
        }

        public async Task<IEntityCollection<IDownload>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<DownloadBase>>("/downloads", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<DownloadBase>> downloads)
            {
                return new EntityCollection<IDownload>(downloads.Data.Select(download => new Download(download)));
            }

            throw new Exception();
        }

        public async Task<IDownload> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<DownloadBase>($"/downloads/{id}", cancellationToken);

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
                return new Download(download.Data);
            }

            throw new Exception();
        }

        public async Task<IDownload> Post(string title, string shortDescription, string longDescription, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<DownloadBase>("/downloads", new
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
                return new Download(download.Data);
            }

            throw new Exception();
        }

        public async Task Delete(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"/downloads/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }
        }
    }
}
