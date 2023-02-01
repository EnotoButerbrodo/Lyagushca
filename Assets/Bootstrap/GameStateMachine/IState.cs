namespace Bootstrap.GameStateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IExitableState
    {
        void UpdateState();
        void Exit();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}