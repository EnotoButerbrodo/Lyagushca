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
        private void Construct(Actor player, Controls controls)
        {
            _player = player;
            _controls = controls;

            _controls.Enable();
            OnChargeBegin = (c) => _player.HandleButtonPress();
            OnChargeRelesed = (c) => _player.HandleButtonRelease();
            BindEvents();
        }

        private void OnDestroy()
        {
            _controls.Touch.ChargeBegin.performed -= OnChargeBegin;
            _controls.Touch.ChargeReleased.performed -= OnChargeRelesed;
        }

        private void BindEvents()
        {
            _controls.Touch.ChargeBegin.performed += OnChargeBegin;
            _controls.Touch.ChargeReleased.performed += OnChargeRelesed;
        }


    }


}