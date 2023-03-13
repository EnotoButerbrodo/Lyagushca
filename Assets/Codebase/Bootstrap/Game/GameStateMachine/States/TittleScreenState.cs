using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class TittleScreenState : State
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IGame _game;
        
        public TittleScreenState(StateMachine stateMachine
            , IInterfaceService interfaceService
            , IGame game) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _game = game;
        }

        public override void Enter()
        {
            _interfaceService.ShowTittleScreen();
            _game.Resume();
            _stateMachine.Enter<LevelCreateState>();

        }
    }
}