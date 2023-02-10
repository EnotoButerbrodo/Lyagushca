using System;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public class ActorSelectService : IActorSelectService
    {
        public ActorSelectService(IActorFactory actorFactory)
        {
            _actorFactory = actorFactory;
        }

        public event Action<Actor> ActorChanged;
        public bool IsActorSelected => _selectedActor != null;
        public Actor SelectedActor => _selectedActor;

        private IActorFactory _actorFactory;
        private Actor _selectedActor;

        public Actor SelectActor<TActor>(Vector2 position = default(Vector2))
            where TActor : Actor
        {
            _selectedActor = _actorFactory.Get<TActor>(position);
            ActorChanged?.Invoke(_selectedActor);
            return _selectedActor;
        }
    }
}