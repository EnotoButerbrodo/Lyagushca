using EnotoButebrodo;
using EnotoButerbrodo.LevelGeneration;
using Lyaguska.Actors;
using Lyaguska.Services;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindActorFactory();
            BindDistanceCounter();
            BindControls();
            BindTimer();
            BindLevelGeneration();
            BindPlayerControlService();
        }

        private void BindActorFactory()
        {
            var factory = new ActorFactory();
            factory.LoadActors();
            factory.SelectActor<Frog>();

            Container
                .Bind<IActorFactory>()
                .To<ActorFactory>()
                .FromInstance(factory)
                .AsSingle();

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
        
        private void BindLevelGeneration()
        {
            var factory = new ChunkFactory(Container.Resolve<ChunksCollection>(), null);
            LevelGenerationService service = new LevelGenerationService(Container.Resolve<LevelGenerationConfig>(),
                factory, Container.Resolve<IDistanceCounter>());

            Container
                .Bind<ILevelGenerationService>()
                .To<LevelGenerationService>()
                .FromInstance(service)
                .AsSingle();
        }
        
        private void BindPlayerControlService()
        {
            var playerControlService = Container
                .Bind<PlayerControllService>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}