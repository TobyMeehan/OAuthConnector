using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly HttpClient _client;
        private readonly ApiVersion _version;

        public AccountController(HttpClient client, ApiVersion version)
        {
            _client = client;
            _version = version;
        }

        public IHttpRequest Get()
        {
            return _client.Get(_version.Url(Endpoint.Account))
                .OnBadRequest(statusCode =>
                {
                    throw new ApiException(statusCode);
                });
        }
    }
}
