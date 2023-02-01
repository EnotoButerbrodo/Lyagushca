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

        private IJumpForceCharger _charger;
        private Timer _timer;

        [Inject]
        public void Construct(IJumpForceCharger charger, Timer timer)
        {
            _charger = charger;
            _timer = timer;
        }

        protected override void InitializeStates()
        {
            IdleState = new IdleState(this, _charger);
            JumpChargeState = new JumpChargeState(this, _charger);
            JumpState = new JumpState(this, _charger);
            AirState = new AirState(this, _charger);
            BufferedJumpState = new BufferedJumpState(this, _charger,_timer);
        }

        protected override ActorState GetInitialState() => IdleState;

    }



}