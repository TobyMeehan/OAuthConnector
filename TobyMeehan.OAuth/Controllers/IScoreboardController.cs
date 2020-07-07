using TobyMeehan.Http;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IScoreboardController
    {
        IObjectiveController Objectives { get; set; }
        IScoreController Scores { get; set; }

        IHttpRequest Get();
    }
}