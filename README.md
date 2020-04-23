# OAuth Connector
Library for .NET clients to connect to my API. Mostly focused on desktop applications.

[![nuget](https://img.shields.io/nuget/v/TobyMeehan.OAuth)](https://www.nuget.org/packages/TobyMeehan.OAuth/)

## Installation
Install the package using NuGet (TobyMeehan.OAuth), or you can use the binaries attached every release.

## Setup
Before you can use the library you need to have an application registered at [api.tobymeehan.com](https://api.tobymeehan.com). When registering, for a desktop application select 'Native' as application type, and set the redirect uri as http://localhost:port/, where port is some integer, typically 4 - 5 digits. This URL must be http, not https, and you must include the trailing /.

Once your application is registered, you are given a client ID, which you can use to authorise with the API.

## Usage
For documentation on using the connector, see the [Wiki](https://github.com/TobyMeehan/OAuthConnector/wiki), which covers every class, and explains the usage of the scoreboard and transactions.

## Versioning
Versions follow the semantic versioning standard of MAJOR.MINOR.PATCH, however due to the library being inherently linked to versions of the API, there are extra considerations.

- If the API is updated in such a way that means incompatible changes must be made to the library, the major version will be incremented.
- If the API is updated such that endpoints change, but underlying functionality remains the same, the minor version will be incremented.
- If the API is extended, such that existing functionality remains the same, but new functionality is introduced, the minor version will be incremented.

This means that, for the most part, the major version of this library corresponds to the major version of the API, but the minor versions **do not** necessarily correspond. Note that the API is 1 major version ahead of this library.

To follow versions and changes to the API, see my [Website](https://github.com/TobyMeehan/Website) repo.

## Issues
If you experience any problems using the connector, such as bugs or some code you're not sure about, please create an [issue](https://github.com/TobyMeehan/OAuthConnector/issues) so you can get reasonably fast support. Also, if I come across anything that needs fixing, I will create an issue myself, so you can see if it's a known issue and/or if there is a fix.
