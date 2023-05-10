using EnotoButebrodo;
using Lyaguska.Services;
using Zenject;

namespace Lyaguska.Actors.StateMachine
{
    public class FrogStateMachine : ActorStateMachine
    {
        public ActorState IdleState { get; private set; }
        public ActorState JumpChargeState { get; private set; }
        public ActorState JumpState { get; private set; }
        public ActorState AirState { get; private set; }
        public ActorState BufferedJumpState { get; private set; }

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
            AirState = new AirState(this, _charger);
            BufferedJumpState = new BufferedJumpState(this, _charger,_timerService.GetTimer());
        }

        protected override ActorState GetInitialState() => IdleState;

    }



}