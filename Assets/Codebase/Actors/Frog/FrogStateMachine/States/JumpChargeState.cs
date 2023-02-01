using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpChargeState : FrogState
    {
        private IJumpForceCharger _charger;
        public JumpChargeState(FrogStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            if(_charger.ChargePercent == 0)
            {
                _charger.StartCharge();
            }
        }
        

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            if (_stateMachine.Actor.Grounded)
            {
                _stateMachine.ChangeState(_stateMachine.JumpState);
            }else
            {
                _stateMachine.ChangeState(_stateMachine.BufferedJumpState);
            }
        }
    }



}