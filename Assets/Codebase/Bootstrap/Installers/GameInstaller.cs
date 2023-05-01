using EnotoButerbrodo.StateMachine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateFactory();
            BindGame();
        }

        private void BindStateFactory()
        {
            GameStateFactory factory = new GameStateFactory(Container);

            Container
                .Bind<IStateFactory>()
                .To<GameStateFactory>()
                .FromInstance(factory)
                .AsSingle();
        }

        private void BindGame()
        {
            var game = Container
                .InstantiateComponentOnNewGameObject<Game>();

            Container
                .Bind<IGame>()
                .To<Game>()
                .FromInstance(game)
                .AsSingle();
        }
    }
}