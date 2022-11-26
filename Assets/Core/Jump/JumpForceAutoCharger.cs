using Lyaguska.Core.Config;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class JumpForceAutoCharger : MonoBehaviour, IResetable
{
    public event Action Started;
    public event Action<float> ChargePercentChanged;
    public event Action Charged;
    public event Action Canceled;

    private GameConfig _gameConfig;

    [Inject]
    public void Construct(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public float ChargePercent
    {
        get => _chargePercent;
        private set
        {
            _chargePercent = value;
            ChargePercentChanged?.Invoke(value);
        }
    }
    private float _chargePercent;

    private bool _chargeStarted;
    private bool _chargeCancelRequst;


    public void StartCharge()
    {
        if (_chargeStarted)
        {
            StopCharge();
        }
        StartCoroutine(ChargeCoroutine());
    }

    public void StopCharge()
    {
        _chargeCancelRequst = true;
    }

    private IEnumerator ChargeCoroutine()
    {
        Reset();
        _chargeCancelRequst = false;
        _chargeStarted = true;

        Started?.Invoke();

        float waitTime = _gameConfig.AutoCharge_MaxChargeTimeInSeconds / _gameConfig.AutoCharge_TickCount;
        WaitForSeconds waiter = new WaitForSeconds(waitTime);

        for (float currentTime = 0; currentTime < _gameConfig.AutoCharge_TickCount; currentTime += 1f)
        {
            if (_chargeCancelRequst)
            {
                Canceled?.Invoke();
                break;
            }
            ChargePercent = currentTime / _gameConfig.AutoCharge_TickCount;

            yield return waiter;
        }

        if (_chargeCancelRequst == false)
        {
            ChargePercent = 1;
        }

        Charged?.Invoke();
        _chargeStarted = false;
    }

    public void Reset()
    {
        StopCharge();
        ChargePercent = 0;
    }

}
 
