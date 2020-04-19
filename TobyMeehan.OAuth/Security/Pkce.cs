using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TobyMeehan.OAuth.Security
{
    class Pkce
    {
        public static string GenerateVerifier()
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            Random random = new Random();

            byte[] buffer = new byte[random.Next(43, 129)];
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public static string ChallengeFromVerifier(string codeVerifier)
        {
            string challenge = Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(codeVerifier)));

            challenge = (challenge.EndsWith("=") ? challenge.Remove(challenge.LastIndexOf("=")) : challenge).Replace("+", "-").Replace("/", "_");

            return challenge;
        }
    }
}
