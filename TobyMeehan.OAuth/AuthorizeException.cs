using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string error, string errorMessage) : base($"{error}: {errorMessage}")
        {

        }
    }
}
