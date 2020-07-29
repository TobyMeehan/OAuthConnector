using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TobyMeehan.OAuth.Http
{
    public class HttpResult : IDisposable
    {
        public HttpResult(HttpResponseMessage response)
        {
            Response = response;
        }

        public HttpStatusCode StatusCode => Response.StatusCode;
        public bool IsSuccessStatusCode => Response.IsSuccessStatusCode;

        public HttpResponseMessage Response { get; }

        public HttpResult<T> AddData<T>(T data)
        {
            return new HttpResult<T>(Response, data);
        }

        public virtual void Dispose()
        {
            Response.Dispose();
        }
    }

    public class HttpResult<T> : HttpResult
    {
        public HttpResult(HttpResponseMessage response, T data) : base(response)
        {
            Data = data;
        }

        public T Data { get; set; }

        public override void Dispose()
        {
            Data = null;

            base.Dispose();
        }
    }
}
