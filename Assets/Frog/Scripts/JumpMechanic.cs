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

    private JumpCommand _jumpBuffer;

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

    private bool _jumpInited;


    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Default.ChargePressed.performed += OnChargePressed;
        _controls.Default.ChargeReleased.performed += OnChargeReleased;

        //_actor.GroundLand += OnActorLand;
        //_chargeHandler.Charged += OnCharged;
    } 

    private void OnChargePressed(InputAction.CallbackContext obj)
    {
        if (_actor.Grounded)
        {
            _chargeHandler.StartCharge();
            _jumpInited = true;
        }
    }

    private void OnChargeReleased(InputAction.CallbackContext obj)
    {
        //SaveJump();

        if (_actor.Grounded && _jumpInited)
        {
            _actor.Jump(_chargeHandler.ChargePercent);
            _chargeHandler.Reset();
            _jumpInited = false;
        }
        
        
    }

    private void SaveJump()
    {
        _jumpBuffer = new JumpCommand(_chargeHandler.ChargePercent);
        _chargeHandler.StopCharge();
        HasAutoJump = true;
    }

    private void Jump()
    {
        _jumpBuffer.Execute(_actor);
        _chargeHandler.Reset();
        HasAutoJump = false;
    }

    private IEnumerator JumpCoroutine(JumpCommand jump, float jumpDelay)
    {
        yield return new WaitForSeconds(jumpDelay);
        jump.Execute(_actor);
        _chargeHandler.Reset();
        HasAutoJump = false;
    }

    private void OnCharged()
    {
        if(_actor.Grounded == false)
        {
            SaveJump();
        }
    }

    private void OnActorLand()
    {
        if (HasAutoJump)
        {
            Jump();
        }
    }

}

