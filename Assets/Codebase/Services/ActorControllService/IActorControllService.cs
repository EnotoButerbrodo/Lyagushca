using Lyaguska.Actors;

namespace Lyaguska.Services
{
    public interface IActorControllService 
    {
        void Enable(Actor actor);
        void Disable();
    }
}