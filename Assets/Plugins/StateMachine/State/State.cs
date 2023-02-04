namespace EnotoButerbrodo.StateMachine
{
    public abstract class State : IState
    {
        protected StateMachine _stateMachine;

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public virtual  void UpdateState()
        {
            return;
        }

        public virtual void Exit()
        {
            return;
        }
    }
}