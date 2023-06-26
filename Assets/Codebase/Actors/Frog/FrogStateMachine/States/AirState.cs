using EnotoButebrodo;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class AirState : FrogState
    {
        private IJumpChargeService _charger;
        private Timer _timer;
        
        public AirState(FrogStateMachine stateMachine
            , IJumpChargeService charger
            , Timer timer) : base(stateMachine)
        {
            _charger = charger;
            _timer = timer;
            _timer.Finished += OnTimerFinished;
        }

        public override void Enter()
        {
            
            _stateMachine.Actor.GroundLand += OnGroundLand;
            _stateMachine.Actor.VelocityChanged += OnVelocityChanged;
            _stateMachine.Animator.SetGrounded(false);
        }

        public override void HandleButtonPress()
        {
            if(_stateMachine.Actor.Grounded == false)
            {
                _charger.StartCharge();
            }
        }

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            _timer.Start(0.25f);
        }

        public override void Exit()
        {
            _stateMachine.Actor.GroundLand -= OnGroundLand;
            _stateMachine.Actor.VelocityChanged -= OnVelocityChanged;
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            _stateMachine.Animator.SetVerticalSpeed(velocity.y);
        }

        private void OnGroundLand()
        {
            _stateMachine.Actor.GroundLand -= OnGroundLand;
            _stateMachine.ChangeState(_stateMachine.IdleState);
            _stateMachine.Animator.SetGrounded(true);
            
            _timer.Finished -= OnTimerFinished;
            _timer.Stop();
        }
        
        private void OnTimerFinished(TimerEventArgs obj)
        {
            _charger.Reset();
        }
        
        
    }
}