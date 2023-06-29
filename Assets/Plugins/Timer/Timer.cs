using System;
using UnityEngine;
using Zenject;

namespace EnotoButebrodo
{
    public class Timer
    {
        public event Action<TimerEventArgs> Started;
        public event Action<TimerEventArgs> Ticked;
        public event Action<TimerEventArgs> Finished;

        public bool IsActive => _isActive;

        private float _currentTime;
        private float _targetTime;

        private bool _isActive;

        public void Start(float timeInSeconds)
        {
            _isActive = true;
            _targetTime = timeInSeconds;
            _currentTime = 0;

            Started?.Invoke(GetArgs());
        }

        public void Stop()
        {
            _isActive = false;
            _targetTime = 0;
        }

        public void UpdateTime(float deltaTime)
        {
            if (_isActive == false)
                return;
            
            _currentTime += deltaTime;

            Ticked?.Invoke(GetArgs());
            
            if (IsTimeout())
            {
                Finished?.Invoke(GetArgs());
                Stop();
            }
        }

        private bool IsTimeout()
            => _currentTime >= _targetTime;

        private TimerEventArgs GetArgs()
            => new(_currentTime, _targetTime);
    }
}
