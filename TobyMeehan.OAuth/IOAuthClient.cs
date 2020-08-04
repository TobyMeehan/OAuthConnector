using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth
{
    public interface IOAuthClient
    {
        /// <summary>
        /// The current registered OAuth application.
        /// </summary>
        IApplication Application { get; }

        /// <summary>
        /// All downloads as of the time of signing in.
        /// </summary>
        IEntityCollection<IDownload> Downloads { get; }

        /// <summary>
        /// Authorization tokens for the API.
        /// </summary>
        Token Token { get; }

        /// <summary>
        /// The current signed in user.
        /// </summary>
        IUser User { get; }

        /// <summary>
        /// Signs in the user using the PKCE OAuth extension.
        /// </summary>
        /// <param name="localhostPort">Port component of the localhost redirect URI set for this application.</param>
        /// <param name="customSuccessFilePath">Path of custom HTML file to display when authorisation succeeds, relative to the path of this application.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task<bool> SignInAsync(int localhostPort, string customSuccessFilePath = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Signs in the user using a refresh token for an existing session.
        /// </summary>
        /// <param name="refreshToken">Refresh token obtained when the last sign in took place.</param>
        /// <param name="redirectUri">Redirect URI previously specified when signing in.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task<bool> SignInAsync(string refreshToken, string redirectUri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Signs the user in using the traditional authorization code grant.
        /// </summary>
        /// <param name="redirectUri">Redirect URI specified when obtaining the authorization code.</param>
        /// <param name="authorizationCode">Authorization code provided by authorization.</param>
        /// <param name="codeVerifier">If the PKCE extension was used, the generated code verifier.</param>
        /// <param name="cancellationToken">Cancellation token to notify operation should be cancelled.</param>
        /// <returns></returns>
        Task<bool> SignInAsync(string redirectUri, string authorizationCode, string codeVerifier = null, CancellationToken cancellationToken = default);
    }
}