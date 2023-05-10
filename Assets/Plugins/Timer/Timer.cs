using System;
using Zenject;

namespace EnotoButebrodo
{
    public class Timer
    {
        public event Action<TimerEventArgs> Started;
        public event Action<TimerEventArgs> Ticked;
        public event Action<TimerEventArgs> Finished;

        public bool IsStarted => _isStarted;

        private float _currentTime;
        private float _targetTime;

        private bool _isStarted;

        public void Start(float timeInSeconds)
        {
            _isStarted = true;
            _targetTime = timeInSeconds;
            _currentTime = 0;

            Started?.Invoke(GetArgs());
        }

        public void Stop()
        {
            _isStarted = false;
            Finished?.Invoke(GetArgs());
            _targetTime = 0;
        }

        public void UpdateTime(float deltaTime)
        {
            if (_isStarted == false)
                return;
            
            _currentTime += deltaTime;

            Ticked?.Invoke(GetArgs());
            
            if (IsTimeout()) 
                Stop();
        }

        private bool IsTimeout()
            => _currentTime >= _targetTime;

        private TimerEventArgs GetArgs()
            => new(_currentTime, _targetTime);
    }
}
