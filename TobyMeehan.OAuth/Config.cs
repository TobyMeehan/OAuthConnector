using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    class Config
    {
        public static string AuthoriseUrl { get; set; } = "https://api.tobymeehan.com/oauth/authorize";

        public static string TokenUrl { get; set; } = "https://api.tobymeehan.com/oauth/token";

        public static string ApiUrl { get; set; } = "https://api.tobymeehan.com/api";
    }
}
