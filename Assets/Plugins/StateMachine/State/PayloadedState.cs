namespace EnotoButerbrodo.StateMachine
{
    public abstract class PayloadedState<T> : IPayloadedState<T>
    {
        protected StateMachine _stateMachine;

        protected PayloadedState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void Enter(T payload);

        public virtual void UpdateState()
        {
            return;
        }

        public virtual void Exit()
        {
            return;
        }
    }
}