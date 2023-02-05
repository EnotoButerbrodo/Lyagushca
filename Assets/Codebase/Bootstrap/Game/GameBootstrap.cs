using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        [Inject] private DiContainer _container;

        private void Start()
        {
            _stateMachine = new GameStateMachine(_container);
            _stateMachine.Enter<LevelCreateState>();
        }

        private void Update()
        {
            _stateMachine?.UpdateStates();
        }
    }
}