using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string error, string errorMessage) : base($"{error}: {errorMessage}")
        {

        }
    }
}
