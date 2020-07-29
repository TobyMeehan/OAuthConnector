using System.Threading;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Http
{
    public interface IHttp
    {
        Task<HttpResult> DeleteAsync(string url, CancellationToken cancellationToken = default);
        Task<HttpResult<T>> DeleteAsync<T>(string url, CancellationToken cancellationToken = default);
        Task<HttpResult> GetAsync(string url, CancellationToken cancellationToken = default);
        Task<HttpResult<T>> GetAsync<T>(string url, CancellationToken cancellationToken = default);
        Task<HttpResult> PostAsync(string url, object data, CancellationToken cancellationToken = default);
        Task<HttpResult<T>> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default);
        Task<HttpResult> PutAsync(string url, object data, CancellationToken cancellationToken = default);
        Task<HttpResult<T>> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default);
    }
}