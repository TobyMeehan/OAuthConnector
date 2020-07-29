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

        public async Task<HttpResult> GetAsync(string url, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(url, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return new HttpResult(response);
        }

        public async Task<HttpResult<T>> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            var result = await GetAsync(url, cancellationToken);

            T data = SimpleJson.DeserializeObject<T>(await result.Response.Content.ReadAsStringAsync());

            return result.AddData(data);
        }

        public async Task<HttpResult> PostAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(SimpleJson.SerializeObject(data));

            var response = await _client.PostAsync(url, content, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return new HttpResult(response);
        }

        public async Task<HttpResult<T>> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            var result = await PostAsync(url, cancellationToken);

            T responseData = SimpleJson.DeserializeObject<T>(await result.Response.Content.ReadAsStringAsync());

            return result.AddData(responseData);
        }

        public async Task<HttpResult> PutAsync(string url, object data, CancellationToken cancellationToken = default)
        {
            HttpContent content = new StringContent(SimpleJson.SerializeObject(data));

            var response = await _client.PutAsync(url, content, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return new HttpResult(response);
        }

        public async Task<HttpResult<T>> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default)
        {
            var result = await PutAsync(url, cancellationToken);

            T responseData = SimpleJson.DeserializeObject<T>(await result.Response.Content.ReadAsStringAsync());

            return result.AddData(responseData);
        }

        public async Task<HttpResult> DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            var response = await _client.DeleteAsync(url, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return new HttpResult(response);
        }

        public async Task<HttpResult<T>> DeleteAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            var result = await DeleteAsync(url, cancellationToken);

            T data = SimpleJson.DeserializeObject<T>(await result.Response.Content.ReadAsStringAsync());

            return result.AddData(data);
        }
    }
}
