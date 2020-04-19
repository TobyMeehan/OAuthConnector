using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Data
{
    class AuthorizationController
    {
        public async Task<string> GetAuthCode(string clientId, string redirectUri, string codeChallenge = null)
        {
            string authCode = null;
            string state = Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(Environment.UserName)));
            string returnedState = "";

            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(redirectUri);

                listener.Start();

                Process.Start($"https://tobymeehan.com/oauth/authorize?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&state={state}{(codeChallenge != null ? $"&code_challenge={codeChallenge}" : "")}");

                HttpListenerContext context = await listener.GetContextAsync();
                var queryString = context.Request.QueryString;

                authCode = queryString["code"];
                returnedState = queryString["state"];

                string responseString = "<html><body>Authorisation successful. You can now close this tab.</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
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
