using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpMechanic : MonoBehaviour
{
    public event Action<bool> SavedJumpChanged;

    [SerializeField] private Controls _controls;
    [SerializeField] private GameActor _actor;
    [SerializeField] private JumpForceCharger _chargeHandler;

    [SerializeField] private ReloadBar _reloadBar;

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
    }

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();

        _actor.GroundLand += OnActorLand;
        _delayJumpTimer.Finished += () => DisableDelayJump();

        _chargeHandler.ChargeBegin += OnChargeBegin;
        _chargeHandler.JumpCharged += OnChargeFinish;
    }
    private void OnDisable()
    {
        _controls.Disable();

        _actor.GroundLand -= OnActorLand;

        _chargeHandler.ChargeBegin -= OnChargeBegin;
        _chargeHandler.JumpCharged -= OnChargeFinish;
    }

    private void Jump(float percent)
    {
        if (_canJump)
        {
            _canJump = false;

            _actor.Jump(percent);

            _delayJumpTimer.Stop();
            _reloadBar.Hide();
            _chargeHandler.Reset();
        }
    }


    private void OnChargeBegin(float percent)
    {
        _groundJump = _actor.Grounded;
    }

    private void OnChargeFinish(float percent)
    {
        if(percent == 0)
        {
            return;
        }

        if(_actor.Grounded == false)
        {
            EnableDelayJump();
        }
        else
        {
            if (_groundJump)
                Jump(percent);
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

