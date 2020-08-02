using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TobyMeehan.OAuth.Http
{
    public class JsonHttpResult<T> : HttpResult, IHttpResult<T>
    {
        public JsonHttpResult(HttpStatusCode statusCode, string body) : base(statusCode, body)
        {
            Data = SimpleJson.DeserializeObject<T>(body);
        }

        public JsonHttpResult(IHttpResult httpResult) : this(httpResult.StatusCode, httpResult.Body)
        {

        }

        public T Data { get; }
    }
}
