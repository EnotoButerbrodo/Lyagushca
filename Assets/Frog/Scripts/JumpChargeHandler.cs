using System;
using System.Collections;
using UnityEngine;

public class JumpChargeHandler : MonoBehaviour
{
    public event Action Started;
    public event Action<float> ChargePercentChanged;
    public event Action Charged;
    public event Action Canceled;

    [SerializeField][Range(0, 10f)] private float _maxChargeTimeInSeconds = 1f;
    [SerializeField][Range(0, 100)] private int _ticksCount = 20;

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

        float waitTime = _maxChargeTimeInSeconds / _ticksCount;
        WaitForSeconds waiter = new WaitForSeconds(waitTime);

        for (float currentTime = 0; currentTime < _ticksCount; currentTime += 1f)
        {
            if (_chargeCancelRequst)
            {
                Canceled?.Invoke();
                break;
            }
            ChargePercent = currentTime / _ticksCount;

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

