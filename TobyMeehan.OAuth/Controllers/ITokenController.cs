using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public interface ITokenController
    {
        Task<Token> PostAsync(string refreshToken, string redirectUri, string clientId, CancellationToken cancellationToken = default);
        Task<Token> PostAsync(string authorizationCode, string redirectUri, string clientId, string clientSecret = null, string codeVerifier = null, CancellationToken cancellationToken = default);
    }
}