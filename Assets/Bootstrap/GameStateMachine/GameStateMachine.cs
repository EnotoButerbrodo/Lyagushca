using System;
using System.Collections.Generic;
using EnotoButerbrodo.StateMachine;

namespace Lyaguska.Bootstrap.GameStateMachine
{
    public class GameStateMachine : StateMachine
    {
        protected override Dictionary<Type, IExitableState> InitialStates()
        {
            return new Dictionary<Type, IExitableState>();
        }
    }
}