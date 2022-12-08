using System;
using UnityEngine;

namespace Lyaguska.Core
{
    public abstract class Actor : MonoBehaviour, IResetable
    {
        public abstract event Action Jumped;
        public abstract event Action GroundLand;
        public abstract event Action Dead;

        public abstract bool Grounded { get; }

        public abstract void HandleButtonPress();
        public abstract void HandleButtonRelease(); 

        public abstract void Jump(float chargePercent);
        public abstract void Reset();
    }

    



}