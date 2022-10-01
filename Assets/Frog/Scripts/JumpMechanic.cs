using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpMechanic : MonoBehaviour
{
    public event Action<bool> JumpBufferChaged
    {
        add => _jumpsBuffer.BufferChanged += value;
        remove => _jumpsBuffer.BufferChanged -= value;
    }
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
        _jumpsBuffer.Buffer(jump);

        if (_actor.Grounded && _jumpsBuffer.Buffered)
        {
            StartCoroutine(JumpCoroutine(_jumpsBuffer.Get(), 0));
        }
    }
    private IEnumerator JumpCoroutine(JumpCommand jump, float jumpDelay)
    {
        yield return new WaitForSeconds(jumpDelay);
        jump.Execute(_actor);
        _chargeHandler.Reset();


    }

    private void OnActorLand()
    { 
        if (_jumpsBuffer.Buffered)
        {
            StartCoroutine(JumpCoroutine(_jumpsBuffer.Get(), _jumpsDelay));
        }
    }

}

public class JumpCommandBuffer
{
    public event Action<bool> BufferChanged;
    public bool Buffered 
    { 
        get => _buffered;
        private set
        {
            _buffered = value;
            BufferChanged?.Invoke(_buffered);
        }
    }
    private bool _buffered;
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

