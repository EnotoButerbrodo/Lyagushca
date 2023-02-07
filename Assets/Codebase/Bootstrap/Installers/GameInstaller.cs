using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGame();
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