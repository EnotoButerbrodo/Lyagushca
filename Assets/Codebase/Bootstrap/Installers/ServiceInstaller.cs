using EnotoButebrodo;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindControls();
        BindTimer();
    }
    
    private void BindTimer()
    {
        Container
            .BindInterfacesAndSelfTo<Timer>()
            .FromInstance(new Timer())
            .AsTransient();
    }
    
    private void BindControls()
    {
        Container
            .Bind<Controls>()
            .FromInstance(new Controls())
            .AsSingle()
            .NonLazy();
    }
}