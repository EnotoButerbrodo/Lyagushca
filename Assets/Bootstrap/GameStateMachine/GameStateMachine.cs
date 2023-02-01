using System;
using System.Collections.Generic;

namespace Bootstrap.GameStateMachine
{
    public class GameStateMachine : StateMachine
    {
        protected override Dictionary<Type, IExitableState> InitialStates()
        {
            return new Dictionary<Type, IExitableState>();
        }
    }
}