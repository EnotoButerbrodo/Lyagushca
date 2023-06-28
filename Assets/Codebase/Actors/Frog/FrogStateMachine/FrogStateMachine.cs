using EnotoButebrodo;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateMachine : ActorStateMachine, IResetable
    {
        [SerializeField] private FrogAnimator _animator;

        [SerializeField] private FrogStateFactory _factory;
        
        public FrogState IdleState { get; private set; }
        public FrogState JumpChargeState { get; private set; }
        public FrogState JumpState { get; private set; }
        public FrogState AirState { get; private set; }

        public FrogAnimator Animator => _animator;
        

        protected override void InitializeStates()
        {
            IdleState = _factory.GetIdleState(this);
            JumpChargeState = _factory.GetJumpChargeState(this);
            JumpState = _factory.GetJumpState(this);
            AirState = _factory.GetAirState(this);
        }

        protected override ActorState GetInitialState() => IdleState;

        public void Reset()
        {
            ChangeState(IdleState);
        }
    }



}