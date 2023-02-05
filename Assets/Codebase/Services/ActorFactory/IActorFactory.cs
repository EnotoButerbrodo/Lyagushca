using Lyaguska.Actors;

namespace Lyaguska.Services
{
    public interface IActorFactory
    {
        Actor CurrentActor { get; }
        void SelectActor<TActor>() where TActor : Actor;
        void LoadActors();
    }
}