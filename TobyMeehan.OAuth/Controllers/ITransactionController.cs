using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface ITransactionController
    {
        Task<IEntityCollection<ITransaction>> GetAsync(CancellationToken cancellationToken = default);
        Task<ITransaction> PostAsync(string description, int amount, bool allowNegative, CancellationToken cancellationToken = default);
    }
}