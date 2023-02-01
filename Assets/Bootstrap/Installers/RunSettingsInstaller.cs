using Lyaguska.Core;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class RunSettingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<Actor>()
                .FromFactory<PlayerGameActorFactory>()
                .AsSingle();
        }
    }
}
