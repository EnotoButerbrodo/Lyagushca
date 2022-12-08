namespace Lyaguska.Core.Actors.StateMachine
{
    public class JumpState : ActorState
    {
        private IJumpForceCharger _charger;
        public JumpState(ActorStateMachine stateMachine, IJumpForceCharger charger) : base(stateMachine)
        {
            _charger = charger;
        }

        public override void Enter()
        {
            _stateMachine.Actor.Jump(_charger.ChargePercent);
            _charger.Reset();
            _stateMachine.SetState(_stateMachine.AirState);
        }
    }



}