using EnotoButerbrodo.StateMachine;
using Lyaguska.Services;
using UnityEngine.SceneManagement;

namespace Lyaguska.Bootstrap
{
    public class GameResetState : State
    {
        private IResetService _resetService;

        public GameResetState(StateMachine stateMachine, IResetService resetService) : base(stateMachine)
        {
            _resetService = resetService;
        }

        public override void Enter()
        {
            _resetService.Reset();
            _stateMachine.Enter<LevelCreateState>();
        }

      
    }
}