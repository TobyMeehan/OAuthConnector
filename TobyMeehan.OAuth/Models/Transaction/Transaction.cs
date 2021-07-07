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
            AppId = transaction.AppId;
            Description = transaction.Description;
            Amount = transaction.Amount;
            Sent = transaction.Sent;
        }

        public static Transaction Create(TransactionBase @base)
        {
            return new Transaction(@base);
        }

        public new IApplication Sender { get; set; }
    }
}
