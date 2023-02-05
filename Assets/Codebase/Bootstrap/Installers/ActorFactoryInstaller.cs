using Lyaguska.Actors;
using Lyaguska.Services;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class ActorFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindActorFactory();
        }
        
        private void BindActorFactory()
        {
            ActorFactory actorFactory = new ActorFactory();
            actorFactory.LoadActors();
            
            actorFactory.SelectActor<Frog>();
            
            Container
                .Bind<IActorFactory>()
                .To<ActorFactory>()
                .FromInstance(actorFactory)
                .AsSingle();
        }
        
    }
}