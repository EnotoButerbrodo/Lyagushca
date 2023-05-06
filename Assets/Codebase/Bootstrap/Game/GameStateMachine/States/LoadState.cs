using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class LoadState : State
    {
        private readonly IUIFactory _uiFactory;

        public LoadState(StateMachine stateMachine, IUIFactory uiFactory) : base(stateMachine)
        {
            _uiFactory = uiFactory;
        }

        public override void Enter()
        {
            _uiFactory.Load();
            
            _stateMachine.Enter<TittleScreenState>();
        }
    }
}