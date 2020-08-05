using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class TransactionBase : EntityBase
    {
        [DataMember(Name = "app_id")]
        public string AppId { get; set; }
        public ApplicationBase Sender { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }
        public UserBase User { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "amount")]
        public int Amount { get; set; }
    }
}
