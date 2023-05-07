using Codebase.Services.ProgressService;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class GameOverState : PayloadedState<int>
    {
        private readonly IInterfaceService _interfaceService;
        private readonly BackgroundSound _backgroundSound;
        private readonly ICameraFollowService _cameraFollow;
        private readonly IProgressService _progress;

        public GameOverState(StateMachine stateMachine
            , IInterfaceService interfaceService
            , BackgroundSound backgroundSound
            , ICameraFollowService cameraFollow
            , IProgressService progress) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _backgroundSound = backgroundSound;
            _cameraFollow = cameraFollow;
            _progress = progress;
        }


        public override void Enter(int distance)
        {
            _backgroundSound.Stop();
            _cameraFollow.Disable();
            _progress.UpdateHighScore(distance);
            _interfaceService.ShowGameOverScreen(distance, _progress.GetHighScore());
        }
    }
}