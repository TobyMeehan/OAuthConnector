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
            if (SimpleJson.TryDeserializeObject(body, out ErrorResponse error))
            {
                Message = error.Message;
            }
            else
            {
                Message = body;
            }            
        }

        public string Message { get; set; }
    }
}
