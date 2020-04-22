# OAuth Connector
Library for .NET clients to connect to my API. Mostly focused on desktop applications.

[![nuget](https://img.shields.io/nuget/v/TobyMeehan.OAuth)](https://www.nuget.org/packages/TobyMeehan.OAuth/)

## Installation
Install the package using NuGet (TobyMeehan.OAuth), or you can use the binaries attached every release.

## Setup
Before you can use the library you need to have an application registered at [api.tobymeehan.com](https://api.tobymeehan.com). When registering, for a desktop application select 'Native' as application type, and set the redirect uri as http://localhost:port/, where port is some integer, typically 4 - 5 digits. This URL must be http, not https, and you must include the trailing /.

Once your application is registered, you are given a client ID, which you can use to authorise with the API.

## Usage
There is more detailed documentation available in the [Wiki](https://github.com/TobyMeehan/OAuthConnector/wiki), which covers every class, and explains the usage of the scoreboard and transactions. The example below demonstrates getting a user signed into a desktop application.

All functionality is exposed through the `OAuthClient` class. There should be a single instance of this class available to all parts of your application, so implement as a singleton in DI, or as a static member somewhere.

To authenticate a user, use the `SignInAsync` method of the client. There are various overloads for different grant and response types. This example demonstrates the PKCE extension for native (desktop) clients.

```cs
static class Foo
{
    public static OAuthClient Client { get; set; } = new OAuthClient();
}

class Program
{
    static async Task Main(string[] args)
    {
        string clientId = "your-client-id";
        int port = 5000 // This is the port if your registered Redirect URI was http://localhost:5000.
    
        await Foo.Client.SignInAsync(clientId, port);
        
        if (Foo.Client.User.IsSignedIn)
        {
            Console.WriteLine("Authenticated.");
        }
    }
}
```

In a production application, do not include the port or client ID directly in source code, instead use configuration or some key vault.

The `SignInAsync` method is designed to fail gracefully, meaning if authorisation fails for any reason, rather than blowing up, it will simply exit. Hence, after calling the method, use `User.IsSignedIn` to check whether authorisation succeeded. If it did, congratulations! You can start actually making use of the API.
