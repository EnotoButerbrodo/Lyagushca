using Lyaguska.Actors;

namespace Lyaguska.Services
{
    public interface IActorDieCheckService
    {
        void CheckDeath();
        void SetActor(Actor actor);
    }
}