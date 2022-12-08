﻿using System;
using UnityEngine.InputSystem;

namespace Lyaguska.Core.Actors.StateMachine
{
    public abstract class ActorState
    {
        protected ActorStateMachine _stateMachine;

        protected ActorState(ActorStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { return; }
        public virtual void Exit() { return; }
        public virtual void HandleButtonPress() { return; }
        public virtual void HandleButtonRelease() { return; }
    }

}