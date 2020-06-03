using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class ApiVersion
    {
        public static ApiVersion Version2
        {
            get
            {
                string url = "https://api.tobymeehan.com/api";
                string authoriseUrl = "https://tobymeehan.com/oauth";

                return new ApiVersion
                {
                    Url = url,
                    AuthoriseUrl = authoriseUrl,
                    Endpoints =
                    {
                        {"authorize", $"{authoriseUrl}/authorize" },
                        {"token", $"{authoriseUrl}/token" },
                        {"account", $"{url}/account" },
                        {"application", $"{url}/application" },
                        {"download", $"{url}/download" },
                        {"scoreboard", $"{url}/scoreboard" },
                        {"transaction", $"{url}/transaction" }
                    }
                };
            }
        }


        public string Url { get; set; }
        public string AuthoriseUrl { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }

    }
}
