using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TobyMeehan.OAuth.Http
{
    public interface IHttpResult
    {
        HttpStatusCode StatusCode { get; }

        string Body { get; }
    }

    public interface IHttpResult<T> : IHttpResult
    {
        T Data { get; }
    }
}
