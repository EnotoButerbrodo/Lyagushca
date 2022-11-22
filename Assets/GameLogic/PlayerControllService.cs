using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerControllService : MonoBehaviour
{
    private GameActor _player;
    private Controls _controls;
    private JumpForceCharger _charger;

    [Inject]
    private void Construct(GameActor player, Controls controls, JumpForceCharger charger)
    {
        _player = player;
        _controls = controls;
        _charger = charger;

        _controls.Enable();
        BindEvents();
    }

    private void BindEvents()
    {
        _controls.Touch.ChargeBegin.performed += OnJumpPressed;
        _controls.Touch.ChargeReleased.performed += OnJumpReleased;
    }

    private void OnJumpPressed(InputAction.CallbackContext c)
    {
        _charger.StartCharge();
    }

    private void OnJumpReleased(InputAction.CallbackContext c)
    {
        _charger.StopCharge(); 
    }

}

