using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class IdleState : FrogState
    {
        private IJumpChargeService _charger;

        public IdleState(FrogStateMachine stateMachine, IJumpChargeService charger) : base(stateMachine)
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
            _stateMachine.ChangeState(_stateMachine.JumpChargeState);
        }

        public override void HandleButtonRelease()
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
        

        public override void Exit()
        {
        }


        
    }



}