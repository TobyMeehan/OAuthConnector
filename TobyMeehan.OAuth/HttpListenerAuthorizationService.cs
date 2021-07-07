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
        private readonly OAuthClientOptions _options;

        public HttpListenerAuthorizationService(OAuthClientOptions options)
        {
            _options = options;
        }

        public async Task<string> GetAuthCodeAsync(string clientId, string redirectUri, string scope, string codeChallenge, Stream responseStream = null)
        {
            string state = GetState();

            string code = "";
            string returnedState = "";

            string url = $"{_options.BaseUrl.AbsoluteUri}oauth/authorize" +
                $"?response_type=code" +
                $"&client_id={clientId}" +
                $"&redirect_uri={WebUtility.UrlEncode(redirectUri)}" +
                $"&scope={WebUtility.UrlEncode(scope)}" +
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

                    if (queryString["error"] != null)
                    {
                        if (queryString["error"] == "access_denied")
                        {
                            throw new AuthorizationCanceledException();
                        }

                        throw new AuthorizationFailedException(queryString["error"], queryString["error_message"]);
                    }

                    code = queryString["code"];
                    returnedState = queryString["state"];

                    context.Response.ContentLength64 = responseStream.Length;
                    await responseStream.CopyToAsync(context.Response.OutputStream);
                    context.Response.OutputStream.Close();
                });
            }

            if (returnedState != state)
            {
                throw new AuthorizationFailedException("state", "Returned state does not match supplied state.");
            }

            return code;
        }

        private string GetState()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
