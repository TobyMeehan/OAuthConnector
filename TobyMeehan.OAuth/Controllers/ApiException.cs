using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TobyMeehan.OAuth.Controllers
{
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ApiException(HttpStatusCode statusCode) : base ($"Server returned status code {statusCode}")
        {

        }
    }
}
