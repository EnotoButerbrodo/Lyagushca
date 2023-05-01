using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;

namespace Lyaguska.Bootstrap
{
    public interface IStateFactory
    {
        Dictionary<Type, IExitableState> GetStates(StateMachine owner);
    }
}