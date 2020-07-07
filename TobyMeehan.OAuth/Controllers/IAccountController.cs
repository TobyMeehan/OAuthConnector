using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IAccountController
    {
        IHttpRequest Get();
    }
}