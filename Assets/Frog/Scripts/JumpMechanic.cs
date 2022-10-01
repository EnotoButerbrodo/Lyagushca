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
    [SerializeField][Range(0, 1f)] private float _jumpsDelay;

    [SerializeField] private int _combo;

    private bool _hasAutoJump;
    private bool HasAutoJump
    {
        get => _hasAutoJump;
        set
        {
            _hasAutoJump = value;
            SavedJumpChanged?.Invoke(value);
        }
    }
    private float _savedJumpPercent;

    private bool _jumpInited;
    private bool _canJump = true;

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
        _chargeHandler.Charged += OnCharged;
    }
    
    private void Jump(float percent)
    {
        if (_canJump)
        {
            _actor.Jump(percent);
            _chargeHandler.Reset();
            _canJump = false;
        }
    }

    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        _chargeHandler.StartCharge();
        _jumpInited = true;
    }

    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        //SaveJump();
        if(_jumpInited == false)
        {
            return;
        }

        _chargeHandler.StopCharge();
        _jumpInited = false;

        if (_actor.Grounded)
        {
            Jump(_chargeHandler.ChargePercent);
            _chargeHandler.Reset();
            HasAutoJump = false;
        }
        else
        {
            HasAutoJump = true;
            _savedJumpPercent = _chargeHandler.ChargePercent;
        }

    }
    private void OnCharged()
    {
        if (_actor.Grounded == false && _chargeHandler.ChargePercent == 1f)
        {
            _savedJumpPercent = _chargeHandler.ChargePercent;
            HasAutoJump = true;
        }
    }

    private void OnActorLand()
    {
        _canJump = true;
        if (HasAutoJump)
        {
            StartCoroutine(DelayedJump());
        }
    }

    private IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(_jumpsDelay);
        Jump(_savedJumpPercent);

        HasAutoJump = false;
    }

}

