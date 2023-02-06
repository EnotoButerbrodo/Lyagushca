using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class JumpChargeService : MonoBehaviour, IJumpChargeService
    {
        public event Action<float> ChargeBegin;
        public event Action<float> ChargePercentChanged;
        public event Action<float> JumpCharged;

        public float ChargePercent
        {
            get => _chargePercent;
            set
            {
                _chargePercent = value;
                ChargePercentChanged?.Invoke(value);
            }
        }

        private float _chargePercent;
        private bool _chargeStarted;
        private bool _chargeCancelRequst;

        private JumpsConfig _gameConfig;

        [Inject]
        private void Construct(JumpsConfig config)
        {
            _gameConfig = config;
        }

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

        public void Reset()
        {
            StopCharge();
            ChargePercent = 0;
        }

        private IEnumerator ChargeCoroutine()
        {
            Reset();
            _chargeCancelRequst = false;
            _chargeStarted = true;

            ChargeBegin?.Invoke(0);

            float waitTime = _gameConfig.AutoCharge_MaxChargeTimeInSeconds / _gameConfig.AutoCharge_TickCount;
            WaitForSeconds waiter = new WaitForSeconds(waitTime);

            for (int currentTime = 1; currentTime < _gameConfig.AutoCharge_TickCount; currentTime++)
            {
                if (_chargeCancelRequst)
                {
                    break;
                }
                ChargePercent = (float)currentTime / _gameConfig.AutoCharge_TickCount;

                yield return waiter;
            }

            if (_chargeCancelRequst == false)
            {
                ChargePercent = 1;
            }

            JumpCharged?.Invoke(ChargePercent);
            _chargeStarted = false;
        }

      

    }
}