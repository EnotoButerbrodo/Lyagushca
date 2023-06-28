using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class IdleState : FrogState
    {
        private IJumpChargeService _charger;

        public IdleState(FrogStateMachine context, IJumpChargeService charger) : base(context)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            if(_charger.IsCharging == false) 
                HandleDelayedJump();    
        }
        
        public override void HandleButtonPress()
        {
            Context.ChangeState(Context.JumpChargeState);
        }

        public override void HandleButtonRelease()
        {
            HandleDelayedJump();
        }

        private void HandleDelayedJump()
        {
            if (_charger.ChargePercent > 0 && Context.Actor.Grounded)
            {
                Context.ChangeState(Context.JumpState);
            }
        }
        

        public override void Exit()
        {
        }


        
    }



}