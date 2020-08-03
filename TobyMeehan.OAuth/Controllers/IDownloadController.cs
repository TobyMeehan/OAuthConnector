using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IDownloadController
    {
        Task Delete(string id, CancellationToken cancellationToken = default);
        Task<IEntityCollection<IDownload>> GetAsync(CancellationToken cancellationToken = default);
        Task<IDownload> GetAsync(string id, CancellationToken cancellationToken = default);
        Task<IDownload> Post(string title, string shortDescription, string longDescription, CancellationToken cancellationToken = default);
    }
}