using System;
using Lyaguska.Actors.StateMachine;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class FrogDieHandler : MonoBehaviour, IResetable
    {
        [SerializeField] private FrogStateMachine _frogStateMachine;
        public event Action Dead;
        
        public bool IsDead { get; private set; }


        public void Die()
        {
            IsDead = true;
            _frogStateMachine.ChangeState(_frogStateMachine.DeadState);

            Dead?.Invoke();
        } 
        
        public void Reset()
        {
            IsDead = false;
        }
    }
}