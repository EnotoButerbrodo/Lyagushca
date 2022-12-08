﻿using System;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core
{
    public class Timer : ITickable
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

        void ITickable.Tick()
        {
            if (_isStarted)
            {
                _currentTime += Time.deltaTime;

                Ticked?.Invoke(GetArgs());

                if (Check())
                {
                    Stop();
                }
            }
        }

        private bool Check()
            => _currentTime >= _targetTime;

        private TimerEventArgs GetArgs()
            => new(_currentTime, _targetTime);

    }

    public class TimerEventArgs
    {
        public float CurrentTime { get; private set; }
        public float MaxTime { get; private set; }

        public TimerEventArgs(float currentTime, float maxTime)
        {
            CurrentTime = currentTime;
            MaxTime = maxTime;
        }
    }
}
