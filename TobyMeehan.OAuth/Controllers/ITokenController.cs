using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface ITokenController
    {
        IHttpRequest PostPkce(string clientId, string redirectUri, string codeVerifier, string authCode);
        IHttpRequest PostServer(string clientId, string redirectUri, string secret, string authCode);
    }
}