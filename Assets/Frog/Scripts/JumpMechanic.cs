﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpMechanic : MonoBehaviour
{
    [SerializeField] private Controls _controls;
    [SerializeField] private GameActor _actor;
    [SerializeField] private JumpChargeHandler _chargeHandler;
    [SerializeField][Range(0, 1f)] private float _jumpsDelay;

    private JumpCommandBuffer _jumpsBuffer = new JumpCommandBuffer();

    [SerializeField] private int _combo;


    //Получить запрос на прыжок
    //Если в воздухе - начать зарядку
    //После отпуска кнопки - создать команду на прыжок
    //После приземления подождать время задержки
    //Выполнить команду
    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Default.ChargePressed.performed += OnChargePressed;
        _controls.Default.ChargeReleased.performed += OnChargeReleased;

        _actor.GroundLand += OnActorLand;
    }

    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        _chargeHandler.StartCharge();
    }

    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        _chargeHandler.StopCharge();
        JumpCommand jump = new JumpCommand(_chargeHandler.ChargePercent);
        if (_actor.Grounded)
        {
            jump.Execute(_actor);
            _chargeHandler.Reset();
        }
        else
        {
            _jumpsBuffer.Buffer(jump);
        }
    }
    private IEnumerator JumpCoroutine(JumpCommand jump)
    {
        yield return new WaitForSeconds(_jumpsDelay);
        jump.Execute(_actor);
        _chargeHandler.Reset();
        
    }

    private void OnActorLand()
    { 
        if (_jumpsBuffer.Buffered)
        {
            StartCoroutine(JumpCoroutine(_jumpsBuffer.Get()));
        }
    }

}

public class JumpCommandBuffer
{
    public bool Buffered { get; private set; }
    private JumpCommand _jumpCommand;

    public void Buffer(JumpCommand jumpCommand)
    {
        _jumpCommand = jumpCommand;
        Buffered = true;
    }

    public JumpCommand Get()
    {
        Buffered = false;
        return _jumpCommand;
    }
}

