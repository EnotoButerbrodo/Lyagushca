using Lyaguska.Core;
using Zenject;

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
