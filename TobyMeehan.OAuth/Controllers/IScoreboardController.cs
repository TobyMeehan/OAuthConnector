using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IScoreboardController
    {
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task<IEntityCollection<IObjective>> GetAsync(CancellationToken cancellationToken = default);
        Task<IObjective> GetAsync(string id, CancellationToken cancellationToken = default);
        Task<IObjective> PostAsync(string name, CancellationToken cancellationToken = default);
        Task PutScoreAsync(string id, string userId, int value, CancellationToken cancellationToken = default);
    }
}