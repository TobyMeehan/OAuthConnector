using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public interface IScoreCollection : IEnumerable<IScore>
    {
        /// <summary>
        /// Gets the score for the given user.
        /// </summary>
        /// <param name="userId">ID of the required user.</param>
        /// <returns></returns>
        IScore this[string userId] { get; }
    }
}
