using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpMechanic : MonoBehaviour
{
    public event Action<bool> SavedJumpChanged;

    [SerializeField] private Controls _controls;
    [SerializeField] private GameActor _actor;
    [SerializeField] private JumpChargeHandler _chargeHandler;
    [SerializeField][Range(0, 1f)] private float _delayJumpTime;
    [SerializeField] private Timer _delayJumpTimer;
    [SerializeField][Range(0, 1f)] private float _jumpsDelay;

    private float _savedPercent;

    private bool _hasDelayedJump;
    private bool HasDelayedJump
    {
        get => _hasDelayedJump;
        set
        {
            _hasDelayedJump = value;
            SavedJumpChanged?.Invoke(value);
        }
    }


    private bool _canJump = true;
    private bool _groundJump;

    private void EnableDelayJump()
    {
        _delayJumpTimer.StartTimer(_delayJumpTime);
        HasDelayedJump = true;
    }

    private void DisableDelayJump()
    {
        HasDelayedJump = false;
        _chargeHandler.Reset();
    }

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
        _delayJumpTimer.Finished += () => DisableDelayJump();

    }
    private void OnDisable()
    {
        _controls.Disable();
        _controls.Default.ChargePressed.performed -= OnChargePressed;
        _controls.Default.ChargeReleased.performed -= OnChargeReleased;

        _actor.GroundLand -= OnActorLand;
    }

    private void Jump(float percent)
    {
        if (_canJump)
        {
            _canJump = false;

            _actor.Jump(percent);

            _chargeHandler.Reset();

            _delayJumpTimer.Stop();
        }
    }

    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        _chargeHandler.StartCharge();
        _groundJump = _actor.Grounded;
        
    }

    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        _chargeHandler.StopCharge();
        if (_actor.Grounded == false)
        {
            EnableDelayJump();
        }
        else
        {
            if (_groundJump)
                Jump(_chargeHandler.ChargePercent);
            else
                StartCoroutine(DelayedJump());
        }

    }


    private void OnActorLand()
    {
        _canJump = true;
        if (_delayJumpTimer.IsStarted)
        {
            StartCoroutine(DelayedJump());
        }
    }

    private IEnumerator DelayedJump()
    {
        _savedPercent = _chargeHandler.ChargePercent;
        yield return new WaitForSeconds(_jumpsDelay);
        Jump(_savedPercent);
    }
}

