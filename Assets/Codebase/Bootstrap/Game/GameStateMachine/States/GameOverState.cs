using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<float>
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IGame _game;
        private readonly BackgroundSound _backgroundSound;

        public GameOverState(StateMachine stateMachine, IInterfaceService interfaceService, IGame game, BackgroundSound backgroundSound) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _game = game;
            _backgroundSound = backgroundSound;
        }


        public override void Enter(float distance)
        {
            _backgroundSound.Stop();
            _game.Pause();
            _interfaceService.ShowGameOverScreen(distance);
        }
    }
}