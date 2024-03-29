﻿using System;
using System.Collections;
using Lyaguska.Bootstrap;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class JumpChargeService : IJumpChargeService
    {
        public event Action<float> ChargeBegin;
        public event Action<float> ChargePercentChanged;
        public event Action<float> ChargeEnd;
        public event Action<float> DechargeBegin;
        public event Action<float> DechargeEnd; 
        public event Action Showed;
        public event Action Hided;
        
        public float ChargePercent
        {
            get => _chargePercent;
            set
            {
                _chargePercent = value;
                ChargePercentChanged?.Invoke(value);
            }
        }

        public bool IsCharging { get; private set; }

        private float _chargePercent;

        private JumpsConfig _gameConfig;
        private ICoroutineRunner _coroutineRunner;
        
        private Coroutine _chargeCoroutine;
        private bool _isPaused;

        
        public JumpChargeService(JumpsConfig gameConfig
            , ICoroutineRunner coroutineRunner)
        {
            _gameConfig = gameConfig;
            _coroutineRunner = coroutineRunner;
        }

        public void StartCharge()
        {
            if (_chargeCoroutine == null) 
                StopCharge();

            IsCharging = true;
            
            Show();
            ChargeBegin?.Invoke(0);
            ChargePercent = 0;
            _chargeCoroutine = _coroutineRunner.StartCoroutine(ChargeCoroutine());
        }

        public void StopCharge()
        {
            if(_chargeCoroutine != null)
                _coroutineRunner.StopCoroutine(_chargeCoroutine);

            IsCharging = false;
        }

        public void Show() 
            => Showed?.Invoke();

        public void Hide() 
            => Hided?.Invoke();

        public void Reset()
        {
            StopCharge();
            ChargePercent = 0;
            Hide();
        }

        private IEnumerator ChargeCoroutine()
        {
            float waitTime = _gameConfig.AutoCharge_MaxChargeTimeInSeconds / _gameConfig.AutoCharge_TickCount;
            WaitForSeconds waiter = new WaitForSeconds(waitTime);
            WaitForSeconds chargesDelay = new WaitForSeconds(.25f);
  

            for (int currentTime = 1; currentTime < _gameConfig.AutoCharge_TickCount; currentTime++)
            {
                while(_isPaused)
                    yield return null;
                
                ChargePercent = (float)currentTime / _gameConfig.AutoCharge_TickCount;

                yield return waiter;
            }

            ChargePercent = 1;
            ChargeEnd?.Invoke(ChargePercent);
            
            yield return chargesDelay;
            
            DechargeBegin?.Invoke(1);
            for (int currentTime = _gameConfig.AutoCharge_TickCount; currentTime > 0; currentTime--)
            {
                while(_isPaused)
                    yield return null;
                
                ChargePercent = (float)currentTime / _gameConfig.AutoCharge_TickCount;

                yield return waiter;
            }

            ChargePercent = 0;
            DechargeEnd?.Invoke(0);
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}