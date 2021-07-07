using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class OAuthClientOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri BaseUrl { get; set; }
    }
}
