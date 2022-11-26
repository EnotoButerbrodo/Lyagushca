using Lyaguska.Core.Config;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core
{
    public class JumpForceCharger : MonoBehaviour, IResetable
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

        private GameConfig _gameConfig;

        [Inject]
        private void Construct(GameConfig config)
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

        private IEnumerator ChargeCoroutine()
        {
            Reset();
            _chargeCancelRequst = false;
            _chargeStarted = true;

            ChargeBegin?.Invoke(0);

            float waitTime = _gameConfig.AutoCharge_MaxChargeTimeInSeconds / _gameConfig.AutoCharge_TickCount;
            WaitForSeconds waiter = new WaitForSeconds(waitTime);


            for (float currentTime = 0f; currentTime < _gameConfig.AutoCharge_TickCount + 1; currentTime += 1f)
            {
                if (_chargeCancelRequst)
                {
                    break;
                }
                ChargePercent = (float)(currentTime / _gameConfig.AutoCharge_TickCount);

                yield return waiter;
            }

            if (_chargeCancelRequst == false)
            {
                ChargePercent = 1;
            }

            JumpCharged?.Invoke(ChargePercent);
            _chargeStarted = false;
        }

        public void Reset()
        {
            StopCharge();
            ChargePercent = 0;
        }

        //}

        //public class JumpForceCharger2 : MonoBehaviour, IJumpForceCharger, IResetable
        //{
        //    public event Action<float> ChargeBegin;
        //    public event Action<float> ChargePercentChanged;
        //    public event Action<float> JumpCharged;

        //    private GameConfig _gameConfig;


        //    private Camera _camera;

        //    private TouchInput _input;

        //    private JumpForceAutoCharger _autoCharger;

        //    private bool _autoCharge;

        //    private Vector2 _startPoint;

        //    private float _chargePercent;

        //    public float ChargePercent
        //    {
        //        get => _chargePercent;
        //        set
        //        {
        //            _chargePercent = value;
        //            ChargePercentChanged?.Invoke(value);
        //        }
        //    }

        //    [Inject]
        //    public void Construct(TouchInput input, JumpForceAutoCharger autoCharger, GameConfig gameConfig)
        //    {
        //        _input = input;
        //        _autoCharger = autoCharger;
        //        _camera = Camera.main;
        //        _gameConfig = gameConfig;

        //        _input.TouchBegin += OnTouchBegin;
        //        _input.TouchEnd += OnTouchEnd;
        //        _input.TouchMove += OnTouchMove;

        //        _autoCharger.ChargePercentChanged += (value) => ChargePercent = value;
        //    }

        //    public void Reset()
        //    {
        //        ChargePercent = 0;
        //    }

        //    private void StartAutoCharge()
        //    {
        //        _autoCharger.StartCharge();
        //        _autoCharge = true;
        //    }

        //    private void StopAutoCharge()
        //    {
        //        _autoCharger.StopCharge();
        //        _autoCharge = false;
        //    }

        //    private void OnTouchBegin(Vector2 touchPosition)
        //    {
        //        _startPoint = new Vector2(touchPosition.x / _camera.pixelWidth, touchPosition.y / _camera.pixelHeight);
        //        ChargePercent = 0;
        //        ChargeBegin?.Invoke(ChargePercent);
        //        //_gameConfig.JumpCharge_RadiusImage.enabled = true;
        //        //_gameConfig.JumpCharge_RadiusImage.transform.position = touchPosition;

        //        StartAutoCharge();

        //    }

        //    private void OnTouchMove(Vector2 touchPosition)
        //    {
        //        Vector2 normalizedPosition = new Vector2(touchPosition.x / _camera.pixelWidth, touchPosition.y / _camera.pixelHeight);
        //        float distance = Vector2.Distance(_startPoint, normalizedPosition);
        //        if (distance < _gameConfig.JumpCharge_MinRadius)
        //        {
        //            if (_autoCharge == false)
        //            {
        //                ChargePercent = 0;
        //            }
        //        }
        //        else
        //        {
        //            ChargePercent = Mathf.Clamp01((distance - _gameConfig.JumpCharge_MinRadius) / _gameConfig.JumpCharge_MaxRadius);
        //            StopAutoCharge();
        //        }

        //    }
        //    private void OnTouchEnd(Vector2 touchPosition)
        //    {
        //        JumpCharged?.Invoke(ChargePercent);
        //        _autoCharger.StopCharge();
        //        //_gameConfig.JumpCharge_RadiusImage.enabled = false;
        //    }


    }
}