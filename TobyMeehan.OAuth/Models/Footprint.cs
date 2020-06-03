using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Reference to an externally stored entity.
    /// </summary>
    /// <typeparam name="T">Type of external entity.</typeparam>
    public class Footprint<T> : IEntity
    {
        /// <summary>
        /// Internal ID of the entity.
        /// </summary>
        public string Id { get; private set; }
    }
}
