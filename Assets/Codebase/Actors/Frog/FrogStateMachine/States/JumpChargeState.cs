using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpChargeState : FrogState
    {
        private IJumpChargeService _charger;
        public JumpChargeState(FrogStateMachine context, IJumpChargeService charger) : base(context)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            _charger.StartCharge();
            Context.Animator.SetJumpCharging(true);
        }

        public override void UpdateState()
        {
            Context.Animator.SetJumpChargePercent(_charger.ChargePercent);
        }

        public override void Exit()
        {
            Context.Animator.SetJumpCharging(false);
        }

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            Context.ChangeState(Context.JumpState);
        }
    }

}