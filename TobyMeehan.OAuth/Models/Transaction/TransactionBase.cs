using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class TransactionBase : EntityBase
    {
        public string AppId { get; set; }
        public ApplicationBase Sender { get; set; }
        public string UserId { get; set; }
        public UserBase User { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
