using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TobyMeehan.OAuth
{
    public class ApiVersion
    {
        public static ApiVersion Version1
        {
            get
            {
                string url = "https://api.tobymeehan.com/api";
                string authoriseUrl = "https://tobymeehan.com/oauth";

                return new ApiVersion
                {
                    Endpoints =
                    {
                        {Endpoint.Authorize, $"{authoriseUrl}/authorize" },
                        {Endpoint.Token, $"{authoriseUrl}/token" },
                        {Endpoint.Account, $"{url}/account" },
                        {Endpoint.Application, $"{url}/application" },
                        {Endpoint.Download, $"{url}/download" },
                        {Endpoint.Transaction, $"{url}/transaction" },
                        {Endpoint.Scoreboard, $"{url}/scoreboard" },
                        {Endpoint.Objective, $"{url}/scoreboard/objective" },
                        {Endpoint.Score, $"{url}/scoreboard/score" }
                    }
                };
            }
        }


        public Dictionary<Endpoint, string> Endpoints { get; set; }

        public string Url(Endpoint endpoint) => Endpoints[endpoint];
    }

    public enum Endpoint
    {
        Authorize,
        Token,
        Account,
        Application,
        Download,
        Transaction,
        Scoreboard,
        Objective,
        Score
    }
}
