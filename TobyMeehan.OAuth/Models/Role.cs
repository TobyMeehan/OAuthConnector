using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Class representing a user role.
    /// </summary>
    public class Role : EntityBase
    {
        /// <summary>
        /// Name of the role.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

    }
}
