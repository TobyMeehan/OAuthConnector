using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TobyMeehan.OAuth.Controllers;
using TobyMeehan.OAuth.Http;

namespace TobyMeehan.OAuth
{
    public class OAuthClientBuilder
    {
        public static OAuthClient Create(Action<OAuthClientOptions> configureOptions)
        {
            OAuthClientOptions options = DefaultOptions;
            configureOptions?.Invoke(options);

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = options.BaseUrl
            }; 

            IHttp httpService = new Http.Http(httpClient);

            ControllerService controllerService = new ControllerService();

            controllerService.Applications = new ApplicationController(httpService);
            controllerService.Downloads = new DownloadController(httpService, controllerService);
            controllerService.Scoreboard = new ScoreboardController(httpService, controllerService);
            controllerService.Token = new TokenController(httpService);
            controllerService.Users = new UserController(httpService, controllerService);

            IAuthorizationService authorizationService = new HttpListenerAuthorizationService(options);

            return new OAuthClient(controllerService, authorizationService, httpClient, options);
        }

        public static OAuthClientOptions DefaultOptions => new OAuthClientOptions
        {
            BaseUrl = new Uri("https://api.tobymeehan.com"),
            ClientId = null,
            ClientSecret = null
        };
    }
}
