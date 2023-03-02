using System;
using Codebase.Services;
using Lyaguska.Actors;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Lyaguska.Services
{
    public class ActorControllService : IActorControllService, IPauseable
    {
        private IInputService _inputService;
        private Actor _actor;

        public ActorControllService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Enable(Actor actor)
        {
            _actor = actor;
            _inputService.Pressed += OnPressed;
            _inputService.Released += OnReleased;
            
            _inputService.Enable();
        }

        private void OnPressed() 
            => _actor.HandleButtonPress();

        private void OnReleased() 
            => _actor.HandleButtonRelease();

        public void Disable()
        {
            _inputService.Disable();
            _inputService.Pressed -= OnPressed;
            _inputService.Released -= OnReleased;
        }

        void IPauseable.Pause()
        {
            _inputService.Disable();
        }

        void IPauseable.Resume()
        {
            _inputService.Enable();
        }
    }


}