using System;
using UnityEngine.InputSystem;

namespace Codebase.Services
{
    public class InputService : IInputService
    {
        public event Action Pressed;
        public event Action Released;

        private Controls _controls;

        public InputService()
        {
            _controls = new Controls();
            _controls.Touch.ChargeBegin.performed += OnChargeBegin;
            _controls.Touch.ChargeReleased.performed += OnChargeReleased;
        }

        private void OnChargeBegin(InputAction.CallbackContext obj)
        {
            Pressed?.Invoke();
        }

        private void OnChargeReleased(InputAction.CallbackContext obj)
        {
            Released?.Invoke();
        }


        public void Enable()
        {
            _controls.Enable();
        }

        public void Disable()
        {
            _controls.Disable();
        }
    }
}