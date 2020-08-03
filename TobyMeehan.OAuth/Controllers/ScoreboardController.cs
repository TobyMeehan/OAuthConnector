using System;
using System.Collections.Generic;
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

        public ScoreboardController(IHttp http)
        {
            _http = http;
        }

        public async Task<IEntityCollection<IObjective>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<List<ObjectiveBase>>("/applications/@me/scoreboard", cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<List<ObjectiveBase>> scoreboard)
            {
                return scoreboard.Data.ToEntityCollection<IObjective, ObjectiveBase>(x => new Objective(x));
            }

            throw new Exception();
        }

        public async Task<IObjective> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.GetAsync<ObjectiveBase>($"/applications/@me/scoreboard/{id}", cancellationToken);

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
                return new Objective(objective.Data);
            }

            throw new Exception();
        }

        public async Task<IObjective> PostAsync(string name, CancellationToken cancellationToken = default)
        {
            var result = await _http.PostAsync<ObjectiveBase>("/applications/@me/scoreboard", new
            {
                Name = name
            }, cancellationToken);

            if (result is IErrorHttpResult error)
            {
                throw new ApiException(error);
            }

            if (result is IHttpResult<ObjectiveBase> objective)
            {
                return new Objective(objective.Data);
            }

            throw new Exception();
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _http.DeleteAsync($"/applications/@me/scoreboard/{id}", cancellationToken);

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
            var result = await _http.PutAsync($"/applications/@me/scoreboard/{id}/users/{userId}", new
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
