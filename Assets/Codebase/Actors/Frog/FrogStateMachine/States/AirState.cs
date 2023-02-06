using Lyaguska.Services;

namespace Lyaguska.Actors.StateMachine
{
    public class AirState : FrogState
    {
        private IJumpChargeService _charger;
        public AirState(FrogStateMachine stateMachine, IJumpChargeService charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            _stateMachine.Actor.GroundLand += OnGroundLand;
        }

        public override void Exit()
        {
            _stateMachine.Actor.GroundLand -= OnGroundLand;
        }

        private void OnGroundLand()
        {
            _stateMachine.Actor.GroundLand -= OnGroundLand;
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }


        public override void HandleButtonPress()
        {
            if(_stateMachine.Actor.Grounded == false)
            {
                _stateMachine.ChangeState(_stateMachine.JumpChargeState);
            }
        }

    }



}