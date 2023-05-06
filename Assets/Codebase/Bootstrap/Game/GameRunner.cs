using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameRunner : MonoBehaviour
    {
        [Inject] private GameStateMachine _stateMachine;

        private void Start()
        {
            _stateMachine.Enter<LoadState>();
        }

        private void Update()
        {
            _stateMachine.UpdateStates();
        }

    }
}