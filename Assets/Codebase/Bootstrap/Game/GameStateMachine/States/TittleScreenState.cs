using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;

namespace Lyaguska.Bootstrap
{
    public class TittleScreenState : State
    {
        private readonly IInterfaceService _interfaceService;
        private readonly BackgroundSound _backgroundSound;
        private IPauseService _pauseService;

        public TittleScreenState(StateMachine stateMachine
            , IInterfaceService interfaceService
            , IPauseService pauseService
            , BackgroundSound backgroundSound) : base(stateMachine)
        {
            _interfaceService = interfaceService;
            _pauseService = pauseService;
            _backgroundSound = backgroundSound;
        }

        public override void Enter()
        {
            _backgroundSound.Play();
            _interfaceService.ShowTittleScreen();
            _pauseService.Resume(); 
            _stateMachine.Enter<LevelCreateState>();

        }
    }
}