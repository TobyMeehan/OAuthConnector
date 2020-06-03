using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Controllers;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public class ApiRepository<T> : IRepository<T>
    {
        public ApiRepository(IController<T> controller)
        {
            _controller = controller;
        }

        private List<Footprint<T>> _items = new List<Footprint<T>>();
        private readonly IController<T> _controller;

        public Footprint<T> this[string id] => _items.Single(x => x.Id == id);

        public Task<T> CreateAsync(object value)
        {
            return _controller.Create(value);
        }

        public Task<T> GetAsync(string id)
        {
            return _controller.Get(id);
        }

        public Task<T> GetAsync(Footprint<T> footprint)
        {
            return _controller.Get(footprint.Id);
        }

        public IEnumerator<Footprint<T>> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
