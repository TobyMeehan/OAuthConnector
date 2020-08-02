using System.Threading;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Http
{
    public interface IHttp
    {
        Task<IHttpResult> DeleteAsync(string url, CancellationToken cancellationToken = default);
        Task<IHttpResult> DeleteAsync<T>(string url, CancellationToken cancellationToken = default);
        Task<IHttpResult> GetAsync(string url, CancellationToken cancellationToken = default);
        Task<IHttpResult> GetAsync<T>(string url, CancellationToken cancellationToken = default);
        Task<IHttpResult> PostAsync(string url, object data, CancellationToken cancellationToken = default);
        Task<IHttpResult> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default);
        Task<IHttpResult> PutAsync(string url, object data, CancellationToken cancellationToken = default);
        Task<IHttpResult> PutAsync<T>(string url, object data, CancellationToken cancellationToken = default);
    }
}