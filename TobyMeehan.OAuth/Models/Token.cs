using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class Token
    {
        public Token(string accessToken, string type, long expiresIn, string refreshToken)
        {
            AccessToken = accessToken;
            TokenType = type;
            RefreshToken = refreshToken;
            Expiry = DateTime.Now + TimeSpan.FromSeconds(expiresIn);
        }

        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime Expiry { get; set; }
        public string RefreshToken { get; set; }
    }
}
