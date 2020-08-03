using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IUserController
    {
        Task<IEntityCollection<IUser>> GetAsync(CancellationToken cancellationToken = default);
        Task<IUser> GetAsync(string id, CancellationToken cancellationToken = default);
    }
}