namespace Lyaguska.Actors.StateMachine
{
    public interface IFrogStateFactory
    {
        public FrogState GetIdleState(FrogStateMachine context);
        public FrogState GetJumpChargeState(FrogStateMachine context);
        public FrogState GetJumpState(FrogStateMachine context);
        public FrogState GetAirState(FrogStateMachine context);
    }
}