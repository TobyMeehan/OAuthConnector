using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    /// <summary>
    /// Base class representing an entity.
    /// </summary>
    public abstract class EntityBase
    {
        protected readonly HttpClient _client;

        public EntityBase()
        {
            _client = OAuthClient.HttpClient;
        }

        /// <summary>
        /// Internal ID of the entity.
        /// </summary>
        public string Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return typeof(object).IsAssignableFrom(typeof(EntityBase)) && this == (EntityBase)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether two specified entities have the same origin (whether the IDs match).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase x, EntityBase y)
        {
            return x?.Id == y?.Id;
        }

        /// <summary>
        /// Determines whether two specified entities have different origins.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase x, EntityBase y)
        {
            return !(x == y);
        }
    }
}
