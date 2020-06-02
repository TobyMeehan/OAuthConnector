using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public interface IRepository<T> : IEntityCollection<Footprint<T>>
    {
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Footprint<T> footprint);

        Task<T> CreateAsync(object value);
    }
}
