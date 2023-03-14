using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<float>
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IGame _game;
        private readonly BackgroundSound _backgroundSound;
        private readonly ICameraService _camera;

        public GameOverState(StateMachine stateMachine, IInterfaceService interfaceService, IGame game, BackgroundSound backgroundSound, ICameraService camera) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _game = game;
            _backgroundSound = backgroundSound;
            _camera = camera;
        }


        public override void Enter(float distance)
        {
            _backgroundSound.Stop();
            _camera.Disable();
            _interfaceService.ShowGameOverScreen(distance);
        }
    }
}