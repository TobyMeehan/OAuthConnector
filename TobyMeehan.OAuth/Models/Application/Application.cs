using System;
using System.Collections.Generic;
using System.Text;
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
            User = new User(application.User);
        }

        public new IUser User { get; set; }
    }
}
