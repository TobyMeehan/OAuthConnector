using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    public class Application : ApplicationBase, IApplication
    {
        private readonly IApplicationController _controller;

        public Application(IApplicationController controller)
        {
            _controller = controller;
        }

        public static Application Create(ApplicationBase @base, IApplicationController controller)
        {
            return new Application(controller)
            {
                Id = @base.Id,
                UserId = @base.UserId,
                Name = @base.Name,
                Description = @base.Description,
                IconUrl = @base.IconUrl
            };
        }

        public IPartialUser Author { get; set; }

        public IDownload Download { get; set; }
    }
}
