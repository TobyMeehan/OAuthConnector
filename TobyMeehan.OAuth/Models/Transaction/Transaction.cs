using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    
    public class Transaction : TransactionBase, ITransaction
    {
        private Transaction(TransactionBase transaction)
        {
            Id = transaction.Id;
            Description = transaction.Description;
            Amount = transaction.Amount;
        }

        public static async Task<Transaction> CreateAsync(TransactionBase @base, IUserController userController, IApplicationController applicationController, CancellationToken cancellationToken)
        {
            return new Transaction(@base)
            {
                Sender = await applicationController.GetAsync(@base.AppId, cancellationToken),
                User = await userController.GetAsync(@base.UserId, cancellationToken)
            };
        }

        public static async Task<IEntityCollection<ITransaction>> CreateCollectionAsync(IEnumerable<TransactionBase> collection, IUserController userController, IApplicationController applicationController, CancellationToken cancellationToken)
        {
            var entityCollection = new EntityCollection<ITransaction>();

            foreach (var transaction in collection)
            {
                entityCollection.Add(await CreateAsync(transaction, userController, applicationController, cancellationToken));
            }

            return entityCollection;
        }

        public new IApplication Sender { get; set; }
        public new IUser User { get; set; }
    }
}
