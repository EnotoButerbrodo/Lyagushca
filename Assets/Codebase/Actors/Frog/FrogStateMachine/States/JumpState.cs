using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpState : FrogState
    {
        private IJumpForceCharger _charger;
        public JumpState(FrogStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
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