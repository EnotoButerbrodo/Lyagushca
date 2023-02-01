using Lyaguska.Core;

namespace Lyaguska.Actors.Frog.StateMachine
{
    public class BufferedJumpState : FrogState
    {
        private IJumpForceCharger _charger;
        private Timer _timer;
        public BufferedJumpState(FrogStateMachine stateMachine, IJumpForceCharger charger, Timer timer) : base(stateMachine)
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
            _stateMachine.ChangeState(_stateMachine.AirState);
        }

        public override void Exit()
        {
            _stateMachine.Actor.GroundLand -= OnGrounded;
            _timer.Finished -= OnTimerFinished;
            _timer.Stop();
        }

        public override void HandleButtonPress()
        {
            _stateMachine.ChangeState(_stateMachine.JumpChargeState);
        }

        private void OnGrounded()
        {
            _stateMachine.Actor.GroundLand -= OnGrounded;
            _timer.Finished -= OnTimerFinished;
            _timer.Stop();
            _stateMachine.ChangeState(_stateMachine.JumpState);
        }
        
    }

}