using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameStartState : State
    {
        private readonly IScreenService _screenService;

        public GameStartState(StateMachine stateMachine, IScreenService screenService) : base(stateMachine)
        {
            _screenService = screenService;
        }

        public override void Enter()
        {
            _screenService.ShowTittleScreen();
            _stateMachine.Enter<LevelCreateState>();
        }
    }
}