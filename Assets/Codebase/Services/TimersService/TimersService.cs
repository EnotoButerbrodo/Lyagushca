using System.Collections.Generic;
using Lyaguska.Services;
using UnityEngine;

namespace EnotoButebrodo
{
    public class TimersService : MonoBehaviour, ITimersService, IPauseable
    {
        private List<Timer> _timers = new List<Timer>(8);
        private bool _isPaused;
        
        public Timer GetTimer()
        {
            Timer timer = new Timer();
            _timers.Add(timer);

            return timer;
        }

        public void DeleteTimer(Timer timer)
        {
            if (_timers.Contains(timer))
                _timers.Remove(timer);
        }

        private void Update()
        {
            if(_isPaused)
                return;
            
            foreach (Timer timer in _timers)
            {
                timer.UpdateTime(Time.deltaTime);
            }   
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