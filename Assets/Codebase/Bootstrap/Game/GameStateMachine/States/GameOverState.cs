using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<float>
    {
        private readonly IScreenService _screenService;
        private readonly IGame _game;

        public GameOverState(StateMachine stateMachine
            , IScreenService screenService, IGame game) : base(stateMachine)
        {
            _screenService = screenService;
            _game = game;
        }


        public override void Enter(float distance)
        {
            _game.Pause();
            _screenService.ShowGameOverScreen(distance);
        }
    }
}