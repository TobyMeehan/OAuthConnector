using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IDownloadController
    {
        IHttpRequest Get();
        IHttpRequest Get(string id);
    }
}