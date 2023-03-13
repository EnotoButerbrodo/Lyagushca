using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<float>
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IGame _game;

        public GameOverState(StateMachine stateMachine
            , IInterfaceService interfaceService, IGame game) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _game = game;
        }


        public override void Enter(float distance)
        {
            _game.Pause();
            _interfaceService.ShowGameOverScreen(distance);
        }
    }
}