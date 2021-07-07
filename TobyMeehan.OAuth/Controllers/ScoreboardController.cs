using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Controllers
{
    public class ScoreboardController : IScoreboardController
    {
        private readonly IHttp _http;
        private readonly ControllerService _service;

        public ScoreboardController(IHttp http, ControllerService service)
        {
            _http = http;
            _service = service;
        }

        public async Task<IEntityCollection<IObjective>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<ObjectiveBase>>("api/applications/@me/scoreboard", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<ObjectiveBase>> scoreboard)
            {
                EntityCollection<IObjective> collection = new EntityCollection<IObjective>();

                foreach (var objective in scoreboard.Data)
                {
                    var entry = Objective.Create(objective, null, this);
                    entry.Scores = new ScoreCollection(objective.Scores.Select(x => Score.Create(x, entry, this)), entry, this);
                }

                return collection;
            }

            throw new Exception();
        }

        public async Task<IObjective> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<ObjectiveBase>($"api/applications/@me/scoreboard/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new ApiException(error);
            }

            if (result is IHttpResult<ObjectiveBase> objective)
            {
                var entry = Objective.Create(objective.Data, null, this);
                entry.Scores = new ScoreCollection(objective.Data.Scores.Select(x => Score.Create(x, entry, this)), entry, this);
                return entry;
            }

            throw new Exception();
        }

        public async Task<IObjective> PostAsync(string name, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<ObjectiveBase>("api/applications/@me/scoreboard", new
            {
                Name = name
            }, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<ObjectiveBase> objective)
            {
                var entry = Objective.Create(objective.Data, null, this);
                entry.Scores = new ScoreCollection(objective.Data.Scores.Select(x => Score.Create(x, entry, this)), entry, this);
                return entry;
            }

            throw new Exception();
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"api/applications/@me/scoreboard/{id}", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }

                throw new ApiException(error);
            }
        }

        public async Task PutScoreAsync(string id, string userId, int value, CancellationToken cancellationToken = default)
        {
            var result = await _http.PutAsync($"api/applications/@me/scoreboard/{id}/users/{userId}", new
            {
                Value = value
            }, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }
        }
    }
}
