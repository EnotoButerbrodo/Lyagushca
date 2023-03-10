using Lyaguska.Actors;

namespace Lyaguska.Services
{
    public interface IActorControllService
    {
        void Enable();
        void SetActor(Actor actor);
        void Disable();
    }
}