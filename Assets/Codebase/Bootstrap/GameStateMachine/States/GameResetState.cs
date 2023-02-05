using EnotoButerbrodo.StateMachine;
using UnityEngine.SceneManagement;

namespace Lyaguska.Bootstrap
{
    public class GameResetState : State
    {
        public GameResetState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Reset();
            _stateMachine.Enter<LevelCreateState>();
        }

        private void Reset()
        {
            SceneManager.LoadScene(0);
        }
    }
}