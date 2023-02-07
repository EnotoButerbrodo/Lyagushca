using Codebase.Services;
using EnotoButerbrodo.StateMachine;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class PauseState : State
    {
        private IInputService _inputService;

        public PauseState(StateMachine stateMachine, IInputService inputService) : base(stateMachine)
        {
            _inputService = inputService;
        }

        public override void Enter()
        {
            _inputService.Disable();
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            _inputService.Enable();
            Time.timeScale = 1;
            
        }
    }
}