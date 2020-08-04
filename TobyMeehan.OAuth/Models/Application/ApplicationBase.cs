using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    public class ApplicationBase : EntityBase
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
