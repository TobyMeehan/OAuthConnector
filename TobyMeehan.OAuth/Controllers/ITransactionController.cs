using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface ITransactionController
    {
        IHttpRequest Get();
        IHttpRequest Post(string description, int amount);
    }
}