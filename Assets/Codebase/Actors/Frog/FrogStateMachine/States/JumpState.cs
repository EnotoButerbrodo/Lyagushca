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
            if (_charger.ChargePercent == 0)
            {
                _stateMachine.ChangeState(_stateMachine.IdleState);
                return;
            }

            var percent = _charger.ChargePercent;
            
            _stateMachine.Actor.Jump(percent);
            _stateMachine.Animator.SetJump();
            _charger.Reset();
            
            _stateMachine.ChangeState(_stateMachine.AirState);
        }
        
        

      
    }

    
}
