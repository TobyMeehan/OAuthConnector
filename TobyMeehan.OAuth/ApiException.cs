using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TobyMeehan.OAuth.Http;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth
{
    public class ApiException : Exception
    {
        public ApiException(IErrorHttpResult error) : base (error.Message)
        {
            StatusCode = error.StatusCode;
            Body = error.Body;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Url { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            return $"{(int)StatusCode} {StatusCode}: {Message}";
        }
    }
}
