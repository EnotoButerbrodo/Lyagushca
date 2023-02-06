using System;
using Lyaguska.Actors;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Lyaguska.Services
{
    public class ActorControllService : IActorControllService
    {
        private Controls _controls;
        private Action<InputAction.CallbackContext> OnChargeBegin, OnChargeReleased;
        
        public ActorControllService()
        {
            _controls = new Controls();
        }

        public void Enable(Actor actor)
        {
            OnChargeBegin = (c) => actor.HandleButtonPress();
            OnChargeReleased = (c) => actor.HandleButtonRelease();

            _controls.Touch.ChargeBegin.performed += OnChargeBegin;
            _controls.Touch.ChargeReleased.performed += OnChargeReleased;
            
            _controls.Enable();
        }

        public void Disable()
        {
            _controls.Disable();
            
            _controls.Touch.ChargeBegin.performed -= OnChargeBegin;
            _controls.Touch.ChargeReleased.performed -= OnChargeReleased;
        }
        


    }


}