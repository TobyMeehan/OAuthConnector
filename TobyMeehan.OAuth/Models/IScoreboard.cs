using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;

namespace TobyMeehan.OAuth.Models
{
    public interface IScoreboard
    {
        IEntityCollection<IObjective> Objectives { get; }
    }
}
