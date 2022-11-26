﻿using System;
using UnityEngine;

namespace Lyaguska.Core
{
    public abstract class GameActor : MonoBehaviour, IResetable
    {
        public abstract event Action Jumped;
        public abstract event Action GroundLand;
        public abstract event Action Dead;

        public abstract bool Grounded { get; }

        protected GameActorState _state = GameActorState.Idle;

        public abstract void Jump(float chargePercent);
        public abstract void Reset();
    }
}