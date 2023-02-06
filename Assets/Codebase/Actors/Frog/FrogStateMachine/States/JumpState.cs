using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpState : FrogState
    {
        private IJumpChargeService _charger;
        public JumpState(FrogStateMachine stateMachine, IJumpChargeService charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            _stateMachine.Actor.Jump(_charger.ChargePercent);
            _charger.Reset();

            _stateMachine.ChangeState(_stateMachine.AirState);
        }
    }



}