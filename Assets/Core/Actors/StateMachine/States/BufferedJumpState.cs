using System;

namespace Lyaguska.Core.Actors.StateMachine
{
    public class BufferedJumpState : ActorState
    {
        private IJumpForceCharger _charger;
        private Timer _timer;
        public BufferedJumpState(ActorStateMachine stateMachine, IJumpForceCharger charger, Timer timer) : base(stateMachine)
        {
            _charger = charger;
            _timer = timer;
        }

        public override void Enter()
        {
            _stateMachine.Actor.GroundLand += OnGrounded;
            _timer.Finished += OnTimerFinished;
            _timer.Start(timeInSeconds: 0.25f);
        }

        private void OnTimerFinished(TimerEventArgs obj)
        {
            _charger.Reset();
            _stateMachine.SetState(_stateMachine.AirState);
        }

        public override void Exit()
        {
            _stateMachine.Actor.GroundLand -= OnGrounded;
            _timer.Finished -= OnTimerFinished;
            _timer.Stop();
        }

        public override void HandleButtonPress()
        {
            _stateMachine.SetState(_stateMachine.JumpChargeState);
        }

        private void OnGrounded()
        {
            _stateMachine.Actor.GroundLand -= OnGrounded;
            _timer.Finished -= OnTimerFinished;
            _timer.Stop();
            _stateMachine.SetState(_stateMachine.JumpState);
        }
        
    }

}