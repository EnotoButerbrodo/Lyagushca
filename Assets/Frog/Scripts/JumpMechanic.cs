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
  
    }
    private void OnDisable()
    {
        _controls.Disable();
        _controls.Default.ChargePressed.performed -= OnChargePressed;
        _controls.Default.ChargeReleased.performed -= OnChargeReleased;

        _actor.GroundLand -= OnActorLand;

    }
    private void Jump()
    {
        if (_canJump)
        {
            _canJump = false;
            
            _actor.Jump(_chargeHandler.ChargePercent);

            _chargeHandler.StopCharge();
            _chargeHandler.Reset();

            HasDelayedJump = false;
        }
    }
    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        _chargeHandler.StartCharge();
        if(_actor.Grounded == false)
        {
            HasDelayedJump = true;
        }
    }
    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        _chargeHandler.StopCharge();
        if (_actor.Grounded == false)
            return;
       
       if (HasDelayedJump)
       {
           StartCoroutine(DelayedJump());
       }
       else
       {
           Jump();
       }
       
    }


    private void OnActorLand()
    {
        _canJump = true;
        if (HasDelayedJump)
        {
            StartCoroutine(DelayedJump());
        }
    }

    private IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(_jumpsDelay);
        Jump();
    }

}

