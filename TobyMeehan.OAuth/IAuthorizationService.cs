using System.IO;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth
{
    public interface IAuthorizationService
    {
        Task<string> GetAuthCodeAsync(string clientId, string redirectUri, string codeChallenge = null, Stream responseStream = null);
    }
}