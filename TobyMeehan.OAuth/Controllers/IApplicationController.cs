using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IApplicationController
    {
        Task<IApplication> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}