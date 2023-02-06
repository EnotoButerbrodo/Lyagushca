using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface IActorFactory
    {
        Actor Get<TActor>(Vector2 position = default(Vector2)) where TActor : Actor;
        void Load();
    }
}