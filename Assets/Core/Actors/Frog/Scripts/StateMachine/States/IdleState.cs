using Zenject;

namespace Lyaguska.Core.Actors.StateMachine
{
    public class IdleState : FrogState
    {
        private IJumpForceCharger _charger;

        public IdleState(FrogStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            HandleDelayedJump();
        }

        private void HandleDelayedJump()
        {
            if (_charger.ChargePercent > 0 && _stateMachine.Actor.Grounded)
            {
                _stateMachine.ChangeState(_stateMachine.JumpState);
            }
        }

        public override void HandleButtonPress()
        {
            _stateMachine.ChangeState(_stateMachine.JumpChargeState);
        }

        public override void HandleButtonRelease()
        {
            HandleDelayedJump();
        }
    }



}