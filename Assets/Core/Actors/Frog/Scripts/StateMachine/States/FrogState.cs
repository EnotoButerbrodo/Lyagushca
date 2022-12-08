﻿namespace Lyaguska.Core.Actors.StateMachine
{
    public abstract class FrogState : ActorState
    {
        protected FrogStateMachine _stateMachine;
        public FrogState(FrogStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }

}