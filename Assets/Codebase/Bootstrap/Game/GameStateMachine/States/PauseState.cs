using Codebase.Services;
using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class PauseState : State
    {
        private IInputService _inputService;
        private IScreenService _screenService;

        public PauseState(StateMachine stateMachine, IInputService inputService, IScreenService screenService) : base(stateMachine)
        {
            _inputService = inputService;
            _screenService = screenService;
        }
        public override void Enter()
        {
            _inputService.Disable();
            _screenService.ShowPauseScreen();
            Time.timeScale = 0;
        }
        

        public override void Exit()
        {
            _inputService.Enable();
            Time.timeScale = 1;
            
        }
    }
}