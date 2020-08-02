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
    public class UserController : IUserController
    {
        private readonly IHttp _http;

        public UserController(IHttp http)
        {
            _http = http;
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
    }
}
