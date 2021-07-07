using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
