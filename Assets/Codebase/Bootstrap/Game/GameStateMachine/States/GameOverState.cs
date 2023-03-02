using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<float>
    {
        private readonly IScreenService _screenService;
        

        public GameOverState(StateMachine stateMachine, IScreenService screenService) : base(stateMachine)
        {
            _screenService = screenService;
        }

        public override void Enter(float distance)
        {
            _screenService.ShowGameOverScreen(distance);
        }
    }
}