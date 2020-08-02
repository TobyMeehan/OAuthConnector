using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Http
{
    public interface IErrorHttpResult : IHttpResult
    {
        string Message { get; }
    }
}
