using System;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public interface IActorSelectService
    {
        event Action<Actor> ActorChanged;
        Actor SelectedActor { get; }
        
        Actor SelectActor<TActor>(Vector2 position = default(Vector2))
            where TActor : Actor;
    }
}