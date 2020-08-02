using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IUserController
    {
        Task<IUser> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}