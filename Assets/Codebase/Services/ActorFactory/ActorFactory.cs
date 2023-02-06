using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Lyaguska.Actors;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class ActorFactory : IActorFactory
    {
        public event Action<Actor> ActorChanged;
        public Actor CurrentActor => _currentActor;
        private DiContainer _container;
        
        private Actor _currentActor;
        private Dictionary<Type, Actor> _actors;
        private CinemachineVirtualCamera _camera;

        private const string ActorsPath = "Actors";
        private const string CameraPath = "Camera";

        public ActorFactory(DiContainer container)
        {
            _container = container;
        }

        public Actor SelectActor<TActor>(Vector2 position = default(Vector2)) where TActor : Actor
        {
            if (_currentActor != null && _currentActor.GetType() == typeof(TActor))
                return _currentActor;
            
            var actor = _actors[typeof(TActor)];
            
            _currentActor = _container.InstantiatePrefabForComponent<Actor>(actor
                , position
                , Quaternion.identity,
                null);

            ActorChanged?.Invoke(_currentActor);

            return _currentActor;
        } 

        public void Load()
        {
            _actors = Resources.LoadAll<Actor>(ActorsPath)
                .ToDictionary(actor => actor.GetType(), actor => actor);
        }
        
    }
}