using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Controllers
{
    /// <summary>
    /// Specifies that an action of a controller is not defined by the API, but it has been attempted to be used.
    /// </summary>
    public class ActionNotFoundException : Exception
    {
        public ActionNotFoundException(string controller, string action) : base ($"{controller} does not define an action for {action}.")
        {

        }
    }
}
