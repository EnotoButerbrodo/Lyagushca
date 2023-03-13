using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpChargeState : FrogState
    {
        private IJumpChargeService _charger;
        public JumpChargeState(FrogStateMachine stateMachine, IJumpChargeService charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            _charger.StartCharge();
        }

        public override void HandleButtonPress()
        {
            HandleButtonRelease();
        }

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            
            if (_stateMachine.Actor.Grounded)
            {
                _stateMachine.ChangeState(_stateMachine.JumpState);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.BufferedJumpState);
            }
        }
    }



}