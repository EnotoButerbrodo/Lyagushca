using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Codebase.Services.UIControls
{
    [RequireComponent(typeof(Button))]
    public class ButtonControl : MonoBehaviour
    {
        [SerializeField] private InputActionReference _enableAction;

        private Button _button;

        private void OnEnable()
        {
            _enableAction.action.Enable();
            _enableAction.action.performed += OnPerformed;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnDisable()
        {
            _enableAction.action.performed -= OnPerformed;
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            _button.onClick.Invoke();
        }
    }
}