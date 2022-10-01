using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    [SerializeField] Controls _controls;
    [SerializeField] GameActor _actor;
    [SerializeField] private JumpChargeHandler _jumpChargeHandler;
    

    private void Awake()
    {
        _controls = new Controls();
    }


    private void OnJumpButtonReleased(InputAction.CallbackContext obj)
    {
        //_actor.Jump();
    }

    private void OnJumpButtonInitial(InputAction.CallbackContext obj)
    {
        _jumpChargeHandler.StartCharge();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
