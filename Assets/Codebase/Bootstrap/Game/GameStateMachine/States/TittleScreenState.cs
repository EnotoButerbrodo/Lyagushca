using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class TittleScreenState : State
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IGame _game;
        private readonly BackgroundSound _backgroundSound;

        public TittleScreenState(StateMachine stateMachine, IInterfaceService interfaceService, IGame game, BackgroundSound backgroundSound) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _game = game;
            _backgroundSound = backgroundSound;
        }

        public override void Enter()
        {
            _backgroundSound.Play();
            _interfaceService.ShowTittleScreen();
            //_game.Resume();
            _stateMachine.Enter<LevelCreateState>();

        }
    }
}