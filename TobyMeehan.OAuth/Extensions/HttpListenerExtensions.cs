using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Extensions
{
    public static class HttpListenerExtensions
    {
        public static async Task Listen(this HttpListener listener, string url, string redirectUrl, Action<HttpListenerContext> action)
        {
            listener.Prefixes.Add(redirectUrl);
            listener.Start();

            Process.Start(url);

            HttpListenerContext context = await listener.GetContextAsync();

            action.Invoke(context);

            listener.Stop();
        }
    }
}
