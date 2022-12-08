using Zenject;

namespace Lyaguska.Core.Actors.StateMachine
{
    public class AirState : ActorState
    {
        IJumpForceCharger _charger;
        public AirState(ActorStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
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
            _stateMachine.SetState(_stateMachine.IdleState);
        }


        public override void HandleButtonPress()
        {
            if(_stateMachine.Actor.Grounded == false)
            {
                _stateMachine.SetState(_stateMachine.JumpChargeState);
            }
        }

    }



}