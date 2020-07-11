using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Extensions;

namespace TobyMeehan.OAuth
{
    public class HttpListenerAuthorizationService : IAuthorizationService
    {
        private readonly ApiVersion _version;

        public HttpListenerAuthorizationService(ApiVersion version)
        {
            _version = version;
        }

        public async Task<string> GetAuthCodeAsync(string clientId, string redirectUri, string codeChallenge = null, Stream responseStream = null)
        {
            string authCode = null;
            string state = GetState();
            string returnedState = "";

            string url = $"{_version.Url(Endpoint.Authorize)}" +
                $"?response_type=code" +
                $"&client_id={clientId}" +
                $"&redirect_uri={WebUtility.UrlEncode(redirectUri)}" +
                $"&state={WebUtility.UrlEncode(state)}" +
                $"{(codeChallenge != null ? $"&code_challenge={codeChallenge}" : "")}";

            if (responseStream == null)
            {
                string responseString = "<html><body>Authorisation successful. You can now close this tab.</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                responseStream = new MemoryStream(buffer);
            }

            using (HttpListener listener = new HttpListener())
            {
                await listener.Listen(url, redirectUri, async context =>
                {
                    var queryString = context.Request.QueryString;

                    authCode = queryString["code"];
                    returnedState = queryString["state"];

                    context.Response.ContentLength64 = responseStream.Length;
                    await responseStream.CopyToAsync(context.Response.OutputStream);
                    context.Response.OutputStream.Close();
                });
            }

            if (returnedState != state)
            {
                return null;
            }

            return authCode;
        }

        private string GetState()
        {
            int seed = Environment.UserName.GetHashCode();

            byte[] buffer = Array.Empty<byte>();
            new Random(seed).NextBytes(buffer);

            byte[] state = new SHA256Managed().ComputeHash(buffer);
            return Convert.ToBase64String(state);
        }
    }
}
