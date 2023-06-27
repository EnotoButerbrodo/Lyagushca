using EnotoButebrodo;
using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateMachine : ActorStateMachine, IResetable
    {
        public FrogState IdleState { get; private set; }
        public FrogState JumpChargeState { get; private set; }
        public FrogState JumpState { get; private set; }
        public FrogState AirState { get; private set; }

        public FrogAnimator Animator => _animator;
        
        [SerializeField] private FrogAnimator _animator;
        
        private IJumpChargeService _charger;
        private ITimersService _timerService;

        [Inject]
        public void Construct(IJumpChargeService charger, ITimersService timer)
        {
            _charger = charger;
            _timerService = timer;
        }

        protected override void InitializeStates()
        {
            IdleState = new IdleState(this, _charger);
            JumpChargeState = new JumpChargeState(this, _charger);
            JumpState = new JumpState(this, _charger);
            AirState = new AirState(this, _charger, _timerService.GetTimer());
        }

        protected override ActorState GetInitialState() => IdleState;

        public void Reset()
        {
            ChangeState(IdleState);
        }
    }



}