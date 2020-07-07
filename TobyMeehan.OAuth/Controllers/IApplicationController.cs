using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IApplicationController
    {
        IHttpRequest Get();
    }
}