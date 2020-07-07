using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IObjectiveController
    {
        IHttpRequest Delete(string id);
        IHttpRequest Post(string name);
    }
}