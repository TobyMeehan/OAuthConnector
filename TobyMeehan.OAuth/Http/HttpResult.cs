using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TobyMeehan.OAuth.Http
{
    public class HttpResult : IHttpResult
    {
        public HttpResult(HttpStatusCode statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }

        public string Body { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
