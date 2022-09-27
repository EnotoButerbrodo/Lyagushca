using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    [SerializeField] Controls _controls;
    [SerializeField] GameActor _actor;
    

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Keyboard.InitialJump.performed += OnJumpButtonInitial;
        _controls.Keyboard.PerformJump.performed += OnJumpButtonReleased;
    }

    private void OnJumpButtonReleased(InputAction.CallbackContext obj)
    {
        _actor.PerformJump();
    }

    private void OnJumpButtonInitial(InputAction.CallbackContext obj)
    {
        _actor.InitialJump();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
