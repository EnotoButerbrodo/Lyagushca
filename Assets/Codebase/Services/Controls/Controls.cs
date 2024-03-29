//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Codebase/Services/Controls/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""64e5ab96-9692-4612-ae3c-8f6d13492bb0"",
            ""actions"": [
                {
                    ""name"": ""ChargeBegin"",
                    ""type"": ""Button"",
                    ""id"": ""89d4ede7-c70a-46e9-94ec-3f1c82a94bb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChargeReleased"",
                    ""type"": ""Button"",
                    ""id"": ""a2bf5575-949b-4151-a111-f6e5aa4bf368"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcbd047f-8465-4973-baa5-27aa4d71e97f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeBegin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a28389c-92e2-4f0f-99e8-b34a31df5854"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeBegin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac044e44-d547-4567-9bb0-afb795642880"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5b0e0a0-5d3a-458c-b74b-145076f271b5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_ChargeBegin = m_Touch.FindAction("ChargeBegin", throwIfNotFound: true);
        m_Touch_ChargeReleased = m_Touch.FindAction("ChargeReleased", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_ChargeBegin;
    private readonly InputAction m_Touch_ChargeReleased;
    public struct TouchActions
    {
        private @Controls m_Wrapper;
        public TouchActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChargeBegin => m_Wrapper.m_Touch_ChargeBegin;
        public InputAction @ChargeReleased => m_Wrapper.m_Touch_ChargeReleased;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @ChargeBegin.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeBegin;
                @ChargeBegin.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeBegin;
                @ChargeBegin.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeBegin;
                @ChargeReleased.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeReleased;
                @ChargeReleased.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeReleased;
                @ChargeReleased.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnChargeReleased;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChargeBegin.started += instance.OnChargeBegin;
                @ChargeBegin.performed += instance.OnChargeBegin;
                @ChargeBegin.canceled += instance.OnChargeBegin;
                @ChargeReleased.started += instance.OnChargeReleased;
                @ChargeReleased.performed += instance.OnChargeReleased;
                @ChargeReleased.canceled += instance.OnChargeReleased;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ITouchActions
    {
        void OnChargeBegin(InputAction.CallbackContext context);
        void OnChargeReleased(InputAction.CallbackContext context);
    }
}
