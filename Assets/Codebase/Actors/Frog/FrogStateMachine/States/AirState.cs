using EnotoButebrodo;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public class AirState : FrogState
    {
        private readonly IJumpChargeService _charger;
        private readonly ITimersService _timersService;
        private readonly Timer _timer;
        private readonly JumpsConfig _jumpsConfig;

        public AirState(FrogStateMachine context
            , IJumpChargeService charger
            , ITimersService timersService
            , JumpsConfig jumpsConfig) : base(context)
        {
            _charger = charger;
            _timersService = timersService;
            _jumpsConfig = jumpsConfig;
            
            _timer = _timersService.GetTimer();
            _timer.Finished += OnTimerFinished;
        }

        public override void Enter()
        {
            Context.Actor.GroundLand += OnGroundLand;
            Context.Actor.VelocityChanged += OnVelocityChanged;
            Context.Animator.SetFallVelocity(0f);
        }

        public override void HandleButtonPress()
        {
            if(Context.Actor.Grounded == false)
            {
                _charger.StartCharge();
            }
        }

        public override void HandleButtonRelease()
        {
            _charger.StopCharge();
            _timer.Start(_jumpsConfig.DelayJumpTime);
        }

        public override void Exit()
        {
            Context.Actor.GroundLand -= OnGroundLand;
            Context.Actor.VelocityChanged -= OnVelocityChanged;
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            Context.Animator.SetFallVelocity(velocity.y);
        }

        private void OnGroundLand()
        {
            _timer.Stop();
            Context.ChangeState(Context.LandState);
        }
        
        private void OnTimerFinished(TimerEventArgs obj)
        {
            _charger.Reset();
        }
        
        
    }
}