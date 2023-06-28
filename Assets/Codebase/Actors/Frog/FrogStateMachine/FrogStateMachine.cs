using EnotoButebrodo;
using Lyaguska.Handlers;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateMachine : ActorStateMachine, IResetable
    {
        [SerializeField] private FrogAnimator _animator;
        [SerializeField] private FrogSoundHandler _frogSound;
        [SerializeField] private FrogStateFactory _factory;
        
        public FrogState IdleState { get; private set; }
        public FrogState JumpChargeState { get; private set; }
        public FrogState JumpState { get; private set; }
        public FrogState AirState { get; private set; }
        public FrogState LandState { get; private set; }
        
        public FrogAnimator Animator => _animator;
        public FrogSoundHandler FrogSound => _frogSound;
        

        protected override void InitializeStates()
        {
            IdleState = _factory.GetIdleState(this);
            JumpChargeState = _factory.GetJumpChargeState(this);
            JumpState = _factory.GetJumpState(this);
            AirState = _factory.GetAirState(this);
            LandState = _factory.GetLandState(this);
        }

        protected override ActorState GetInitialState() => IdleState;

        public void Reset()
        {
            ChangeState(IdleState);
        }
    }



}