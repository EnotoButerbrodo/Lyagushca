using Lyaguska.Handlers;
using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class JumpState : FrogState
    {
        private IJumpChargeService _charger;

        public JumpState(FrogStateMachine context
            , IJumpChargeService charger) : base(context)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            if (_charger.ChargePercent == 0)
            {
                Context.ChangeState(Context.IdleState);
                return;
            }

            var percent = _charger.ChargePercent;
            
            Context.Actor.Jump(percent);
            Context.Animator.SetJump();
            Context.FrogSound.PlayJump();
            _charger.Reset();
            
            Context.ChangeState(Context.AirState);
        }
        
        

      
    }

    
}
