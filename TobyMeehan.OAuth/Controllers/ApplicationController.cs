using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class ApplicationController : IApplicationController
    {
        private readonly IHttp _http;

        public ApplicationController(IHttp http)
        {
            _http = http;
        }

        public async Task<IApplication> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<ApplicationBase>($"/applications/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new ApiException(error);
            }

            if (result is IHttpResult<ApplicationBase> application)
            {
                return new Application(application.Data);
            }

            throw new Exception();
        }
    }
}
