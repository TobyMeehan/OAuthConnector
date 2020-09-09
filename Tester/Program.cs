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
        static OAuthClient _client = new OAuthClient();

        static async Task Main(string[] args)
        {
            string clientId = "43ac0ad1-8498-11ea-978f-1e37b9fbbec6"; // DO NOT ACTUALLY DO THIS

            Console.WriteLine("Authorising...");

            await _client.SignInAsync(clientId, 6969);

            if (!_client.User.IsSignedIn)
            {
                Console.WriteLine("Authorisation failed :(");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("Signed in.");
            Console.WriteLine();

            var user = await _client.GetSignedInUserAsync();

            Console.WriteLine($"Application Name: {_client.Application.Name}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Balance: {user.Balance}");

            if (user.Roles.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Roles:");

                foreach (var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }

            if (user.Transactions.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Transactions:");

                foreach (var transaction in user.Transactions)
                {
                    Console.WriteLine(transaction.Sender);
                    Console.WriteLine(transaction.Description);
                    Console.WriteLine(transaction.Amount);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Console.Write("Enter amount of money to remove from your account:");

            if (await user.TrySendTransactionAsync("Console Tester", -int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Transaction successful.");
            }

            Console.ReadLine();
        }
    }
}
