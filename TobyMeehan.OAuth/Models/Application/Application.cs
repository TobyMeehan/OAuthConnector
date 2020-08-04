using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public class Application : ApplicationBase, IApplication
    {
        public Application(ApplicationBase application)
        {
            Id = application.Id;
            Name = application.Name;
            Description = application.Description;
            IconUrl = application.IconUrl;
        }

        public new IUser User { get; set; }
    }
}
