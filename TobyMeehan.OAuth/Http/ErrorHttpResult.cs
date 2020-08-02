using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Http
{
    public class ErrorHttpResult : HttpResult, IErrorHttpResult
    {
        public ErrorHttpResult(HttpStatusCode statusCode, string body) : base(statusCode, body)
        {
            ErrorResponse error = SimpleJson.DeserializeObject<ErrorResponse>(body);

            Message = error.Message;
        }

        public string Message { get; set; }
    }
}
