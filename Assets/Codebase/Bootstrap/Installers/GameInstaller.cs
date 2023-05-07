using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
        }

        private void BindStateMachine()
        {
            GameStateFactory factory = new GameStateFactory(Container);
            GameStateMachine stateMachine = new GameStateMachine(factory);
            
            Container
                .Bind<GameStateMachine>()
                .FromInstance(stateMachine)
                .AsSingle();
        }
    }
}