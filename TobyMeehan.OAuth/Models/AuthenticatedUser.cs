using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a user that can be authenticated.
    /// </summary>
    public class AuthenticatedUser : User
    {
        public AuthenticatedUser()
        {
            Id = null;
            Username = null;
        }

        /// <summary>
        /// Whether a user is signed in.
        /// </summary>
        public bool IsSignedIn { get; private set; } = false;

        /// <summary>
        /// If the user is authenticated, gets the API access token for the connection between the user and this application.
        /// </summary>
        public string AccessToken { get; private set; }

        internal void SignIn(string id, string username, string token)
        {
            Id = id;
            Username = username;
            AccessToken = token;
            IsSignedIn = true;
        }

        internal void SignOut()
        {
            Id = null;
            Username = null;
            IsSignedIn = false;
        }
    }
}
