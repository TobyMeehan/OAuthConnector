using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth;

namespace Tester
{
    class Program
    {
        public static OAuthClient Client { get; set; }

        static async Task Main(string[] args)
        {
            Client = OAuthClient.Create(options =>
            {
                options.BaseUrl = new Uri("https://localhost:44301");
                options.ClientId = "46375913-8258-11ea-978f-1e37b9fbbec6";
            });

            if (!await Client.SignInAsync(6969, "identify transactions"))
            {
                Console.WriteLine("Authorization failed.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine($"Signed in as {Client.User.Username}");



            Console.ReadLine();
        }
    }
}
