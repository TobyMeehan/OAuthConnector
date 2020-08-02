using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Http
{
    public class Http : IHttp
    {
        private readonly HttpClient _client;

        public Http(HttpClient client)
        {
            _client = client;
        }

        public async Task<IHttpResult> GetAsync(string url, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.GetAsync(url, cancellationToken))
            {
                string body = await response.Content.ReadAsStringAsync();

                cancellationToken.ThrowIfCancellationRequested();

                if (!response.IsSuccessStatusCode)
                {
                    return new ErrorHttpResult(response.StatusCode, body);
                }
                else
                {
                    return new HttpResult(response.StatusCode, body);
                }
            }
        }

        public async Task<IHttpResult> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            var result = await GetAsync(url, cancellationToken);

            if (result is IErrorHttpResult)
            {
                return result;
            }
            else
            {
                return new JsonHttpResult<T>(result);
            }
        }

        public async Task<IHttpResult> PostAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(SimpleJson.SerializeObject(data));

            using (var response = await _client.PostAsync(url, content, cancellationToken))
            {
                string body = await response.Content.ReadAsStringAsync();

                cancellationToken.ThrowIfCancellationRequested();

                if (!response.IsSuccessStatusCode)
                {
                    return new ErrorHttpResult(response.StatusCode, body);
                }
                else
                {
                    return new HttpResult(response.StatusCode, body);
                }
            }
        }

        public async Task<IHttpResult> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            var result = await PostAsync(url, data, cancellationToken);

            if (result is IErrorHttpResult)
            {
                return result;
            }
            else
            {
                return new JsonHttpResult<T>(result);
            }
        }

        public async Task<IHttpResult> PutAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(SimpleJson.SerializeObject(data));

            using (var response = await _client.PutAsync(url, content, cancellationToken))
            {
                string body = await response.Content.ReadAsStringAsync();

                cancellationToken.ThrowIfCancellationRequested();

                if (!response.IsSuccessStatusCode)
                {
                    return new ErrorHttpResult(response.StatusCode, body);
                }
                else
                {
                    return new HttpResult(response.StatusCode, body);
                }
            }
        }

        public async Task<IHttpResult> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            var result = await PutAsync(url, cancellationToken);

            if (result is IErrorHttpResult)
            {
                return result;
            }
            else
            {
                return new JsonHttpResult<T>(result);
            }
        }

        public async Task<IHttpResult> DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.DeleteAsync(url, cancellationToken))
            {
                string body = await response.Content.ReadAsStringAsync();

                cancellationToken.ThrowIfCancellationRequested();

                if (!response.IsSuccessStatusCode)
                {
                    return new ErrorHttpResult(response.StatusCode, body);
                }
                else
                {
                    return new HttpResult(response.StatusCode, body);
                }
            }
        }

        public async Task<IHttpResult> DeleteAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            var result = await DeleteAsync(url, cancellationToken);

            if (result is ErrorHttpResult)
            {
                return result;
            }
            else
            {
                return new JsonHttpResult<T>(result);
            }
        }
    }
}
