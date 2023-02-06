using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Lyaguska.Actors;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class ActorFactory : IActorFactory
    {
        private DiContainer _container;
        
        private Actor _currentActor;
        private Dictionary<Type, Actor> _actors;
        private CinemachineVirtualCamera _camera;

        private const string ActorsPath = "Actors";

        public ActorFactory(DiContainer container)
        {
            _container = container;
        }

        public Actor Get<TActor>(Vector2 position = default(Vector2)) where TActor : Actor
        {
            if (_currentActor != null && _currentActor.GetType() == typeof(TActor))
            {
                _currentActor.transform.position = position;
                return _currentActor;
            }

            _currentActor = _container
                .InstantiatePrefabForComponent<Actor>(_actors[typeof(TActor)]
                , position
                , Quaternion.identity,
                null);

            return _currentActor;
        } 

        public void Load()
        {
            _actors = Resources.LoadAll<Actor>(ActorsPath)
                .ToDictionary(actor => actor.GetType(), actor => actor);
        }
        
    }
}