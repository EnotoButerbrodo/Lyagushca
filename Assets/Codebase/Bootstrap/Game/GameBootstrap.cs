using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class GameBootstrap : MonoInstaller
    {
        private GameStateMachine _stateMachine;
        [Inject] private DiContainer _container;

        public override void InstallBindings()
        {
            _stateMachine = new GameStateMachine(Container);
            _stateMachine.Enter<BootstrapState>();
        }

        private void Update()
        {
            _stateMachine?.UpdateStates();
        }
    }
}