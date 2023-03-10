using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class TittleScreenState : State
    {
        private readonly IScreenService _screenService;
        private readonly IGame _game;
        
        public TittleScreenState(StateMachine stateMachine
            , IScreenService screenService
            , IGame game) : base(stateMachine)
        {
            _screenService = screenService;
            _game = game;
        }

        public override void Enter()
        {
            _screenService.ShowTittleScreen();
            _game.Resume();
            _stateMachine.Enter<LevelCreateState>();

        }
    }
}