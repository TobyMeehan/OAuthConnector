using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class OAuthClientOptions
    {
        public ApiVersion Version { get; set; }
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string ClientSecret { get; set; }
    }
}
