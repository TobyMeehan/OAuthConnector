using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TobyMeehan.OAuth.Controllers
{
    public interface IController<T>
    {
        // GET: /controller/{id}
        Task<T> Get(string id);

        // GET: /controller
        Task<IEnumerable<T>> Get();

        // POST: /controller
        Task<T> Create(object value);

        // PUT: /controller/{id}
        Task Update(string id, object value);

        // DELETE: /controller/{id}
        Task Delete(string id);
    }
}
