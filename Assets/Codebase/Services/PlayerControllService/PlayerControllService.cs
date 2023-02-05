using System;
using Lyaguska.Actors;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Lyaguska.Services
{
    public class PlayerControllService : MonoBehaviour
    {
        private Actor _player;
        private Controls _controls;

        private Action<InputAction.CallbackContext> OnChargeBegin, OnChargeRelesed;

        [Inject]
        private void Construct(IActorFactory factory, Controls controls)
        {
            _player = factory.CurrentActor;
            _controls = controls;

            _controls.Enable();
            OnChargeBegin = (c) => _player.HandleButtonPress();
            OnChargeRelesed = (c) => _player.HandleButtonRelease();
            BindEvents();
        }


        private void BindEvents()
        {
            _controls.Touch.ChargeBegin.performed += OnChargeBegin;
            _controls.Touch.ChargeReleased.performed += OnChargeRelesed;
        }


    }


}