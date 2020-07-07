using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IScoreController
    {
        IHttpRequest Post(string objective, int score);
    }
}