﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    
    public class Transaction : TransactionBase, ITransaction
    {
        public new IApplication Sender { get; set; }
        public new IUser User { get; set; }
    }
}
