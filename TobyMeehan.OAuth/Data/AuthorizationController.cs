using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Data
{
    class AuthorizationController
    {
        public async Task<string> GetAuthCode(string clientId, string redirectUri, string codeChallenge = null, Stream responseStream = null)
        {
            string authCode = null;
            string state = Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(Environment.UserName)));
            string returnedState = "";

            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(redirectUri);

                listener.Start();

                Process.Start($"{Config.AuthoriseUrl}?response_type=code&client_id={clientId}&redirect_uri={WebUtility.UrlEncode(redirectUri)}&state={WebUtility.UrlEncode(state)}{(codeChallenge != null ? $"&code_challenge={codeChallenge}" : "")}");

                HttpListenerContext context = await listener.GetContextAsync();
                var queryString = context.Request.QueryString;

                authCode = queryString["code"];
                returnedState = queryString["state"];

                if (responseStream == null)
                {
                    string responseString = "<html><body>Authorisation successful. You can now close this tab.</body></html>";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    responseStream = new MemoryStream(buffer);
                }

                context.Response.ContentLength64 = responseStream.Length;
                await responseStream.CopyToAsync(context.Response.OutputStream);
                context.Response.OutputStream.Close();

                listener.Stop();
            }

            if (returnedState != state)
            {
                return null;
            }

            return authCode;
        }
    }
}
