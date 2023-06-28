using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public abstract class Actor : MonoBehaviour, IResetable, IPauseable
    {
        public abstract event Action Jumped;
        public abstract event Action GroundLand;
        public abstract event Action<Vector2> VelocityChanged;
        public abstract event Action Dead;

        public abstract bool Grounded { get; }
        public abstract bool IsDead { get; }

        public abstract void HandleButtonPress();
        public abstract void HandleButtonRelease();

        public abstract void Die();
        
        public abstract void Reset();
        public abstract void Pause();
        public abstract void Resume();
    }
}