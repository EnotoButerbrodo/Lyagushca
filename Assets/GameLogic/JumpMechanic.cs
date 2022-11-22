using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public class JumpMechanic : MonoBehaviour
{
    public event Action<bool> SavedJumpChanged;

    private Controls _controls;
    private JumpForceCharger _charger;
    private GameActor _player;
    private GameConfig _config;

    [SerializeField] private Timer _delayJumpTimer;

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

    [Inject]
    private void Construct(Controls controls, JumpForceCharger charger, GameActor player, GameConfig config)
    {
        _controls = controls;
        _charger = charger;
        _player = player;
        _config = config;

        _player.GroundLand += OnActorLand;
        _delayJumpTimer.Finished += () => DisableDelayJump();

        _charger.ChargeBegin += OnChargeBegin;
        _charger.JumpCharged += OnChargeFinish;

    }

    private bool _canJump = true;
    private bool _groundJump;

    private void EnableDelayJump()
    {
        _delayJumpTimer.StartTimer(_config.DelayJumpTime);
        HasDelayedJump = true;
    }

    private void DisableDelayJump()
    {
        HasDelayedJump = false;
    }

    private void Jump(float percent)
    {
        if (_canJump)
        {
            _canJump = false;

            _player.Jump(percent);

            _delayJumpTimer.Stop();

            //_charger.Reset();
        }
    }


    private void OnChargeBegin(float percent)
    {
        _groundJump = _player.Grounded;
    }

    private void OnChargeFinish(float percent)
    {
        if(percent == 0)
        {
            return;
        }

        if(_player.Grounded == false)
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
            _charger.Reset();
        }
    } 

    private IEnumerator DelayedJump()
    {
        _savedPercent = _charger.ChargePercent;
        yield return new WaitForSeconds(_config.JumpsDelay);
        Jump(_savedPercent);
    }
}

