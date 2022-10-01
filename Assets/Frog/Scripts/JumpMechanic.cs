using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpMechanic : MonoBehaviour
{
    [SerializeField] private Controls _controls;
    [SerializeField] private GameActor _actor;
    [SerializeField] private JumpChargeHandler _chargeHandler;
    [SerializeField][Range(0, 1f)] private float _jumpsDelay;

    private JumpCommand _jumpBuffer;

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
        //_controls.Keyboard.InitialJump.performed += OnJumpButtonInitial;
        //_controls.Keyboard.PerformJump.performed += OnJumpButtonReleased;
    }

    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        _chargeHandler.StartCharge();
    }

    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        _jumpBuffer = new JumpCommand(_chargeHandler.ChargePercent);
        _chargeHandler.StopCharge();
        if(_actor.Grounded)
        {
            _jumpBuffer.Execute(_actor);
            _chargeHandler.Reset();
            _jumpBuffer = null;
        }
    }

    private void OnActorLand()
    { 
        if (_jumpBuffer != null)
        {
            StartCoroutine(AutoJumpCoroutine());
        }
    }

    private IEnumerator AutoJumpCoroutine()
    {
        yield return new WaitForSeconds(_jumpsDelay);
        _jumpBuffer.Execute(_actor);
        _jumpBuffer = null;
        _chargeHandler.Reset();
    }

}
