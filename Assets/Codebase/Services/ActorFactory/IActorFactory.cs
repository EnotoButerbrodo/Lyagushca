using System;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface IActorFactory
    {
        event Action<Actor> ActorChanged; 
        Actor CurrentActor { get; }
        Actor SelectActor<TActor>(Vector2 position = default(Vector2)) where TActor : Actor;
        void Load();
    }
}