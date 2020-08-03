using System;
using System.Collections.Generic;
using System.Text;
using TobyMeehan.OAuth.Models;

namespace TobyMeehan.OAuth.Collections
{
    public interface IScoreCollection : IEnumerable<IScore>
    {
        IScore this[string userid] { get; }
    }
}
