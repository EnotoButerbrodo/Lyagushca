using EnotoButebrodo;
using Lyaguska.Services;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindDistanceCounter();
        BindControls();
        BindTimer();
    }

    private void BindDistanceCounter()
    {
        Container
            .Bind<IDistanceCounter>()
            .To<DistanceCounter>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
    }

    private void BindControls()
    {
        Container
            .Bind<Controls>()
            .FromInstance(new Controls())
            .AsSingle()
            .NonLazy();
    }

    private void BindTimer()
    {
        Container
            .BindInterfacesAndSelfTo<Timer>()
            .FromInstance(new Timer())
            .AsTransient();
    }
}