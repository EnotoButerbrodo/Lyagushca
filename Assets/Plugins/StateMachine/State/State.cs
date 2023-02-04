namespace EnotoButerbrodo.StateMachine
{
    public abstract class State : IState
    {
        protected StateMachine _stateMachine;

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            return;
        }

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