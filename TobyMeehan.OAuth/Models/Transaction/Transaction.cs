using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    
    public class Transaction : TransactionBase, ITransaction
    {
        public Transaction(TransactionBase transaction)
        {
            Id = transaction.Id;
            Description = transaction.Description;
            Amount = transaction.Amount;
            Sender = new Application(transaction.Sender);
            User = new User(transaction.User);
        }

        public new IApplication Sender { get; set; }
        public new IUser User { get; set; }
    }
}
