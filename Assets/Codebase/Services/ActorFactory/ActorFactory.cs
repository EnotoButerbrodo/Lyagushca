using System;
using System.Collections.Generic;
using System.Linq;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Services
{
    public class ActorFactory : IActorFactory
    {
        public Actor CurrentActor => _currentActor;
        
        private Actor _currentActor;
        private Dictionary<Type, Actor> _actors;
        
        private const string ActorsPath = "Actors";

        public void SelectActor<TActor>() where TActor : Actor
        {
            _currentActor = _actors[typeof(TActor)];
        } 

        public void LoadActors()
        {
            _actors = Resources.LoadAll<Actor>(ActorsPath)
                .ToDictionary(actor => actor.GetType(), actor => actor);
        }
        
        private void AddActor<TActor>(TActor actor) where TActor : Actor
        {
            _actors.Add(typeof(TActor), actor);
        }
    }
}