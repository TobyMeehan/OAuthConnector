using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IUserController
    {
        Task<IEntityCollection<IPartialUser>> GetAsync(CancellationToken cancellationToken = default);
        Task<IPartialUser> GetAsync(string id, CancellationToken cancellationToken = default);
        Task<IEntityCollection<IDownload>> GetDownloadsAsync(string id, CancellationToken cancellationToken = default);
        Task LeaveDownloadAsync(string id, string downloadId, CancellationToken cancellationToken = default);
        Task<IEntityCollection<ITransaction>> GetTransactionsAsync(string id, CancellationToken cancellationToken = default);
        Task<ITransaction> PostTransactionAsync(string id, string description, int amount, bool allowNegative, CancellationToken cancellationToken = default);
    }
}