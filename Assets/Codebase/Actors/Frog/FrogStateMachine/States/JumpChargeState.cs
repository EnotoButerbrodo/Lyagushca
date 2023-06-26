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
            _stateMachine.Animator.SetJumpCharging(true);
        }

        public override void UpdateState()
        {
            _stateMachine.Animator.SetJumpChargePercent(_charger.ChargePercent);
        }

        public override void Exit()
        {
            _stateMachine.Animator.SetJumpCharging(false);
        }

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            _stateMachine.ChangeState(_stateMachine.JumpState);
        }
    }

}