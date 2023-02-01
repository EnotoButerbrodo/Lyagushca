using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
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
            _stateMachine.Actor.VelocityChanged += OnVelocityChanged;
        }

        private void HandleDelayedJump()
        {
            if (_charger.ChargePercent > 0 && _stateMachine.Actor.Grounded)
            {
                _stateMachine.ChangeState(_stateMachine.JumpState);
            }
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            if (_stateMachine.Actor.Grounded == false)
            {
                _stateMachine.ChangeState(_stateMachine.AirState);
            }
        }

        public override void Exit()
        {
            _stateMachine.Actor.VelocityChanged -= OnVelocityChanged;
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