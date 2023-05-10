using System.Collections.Generic;
using UnityEngine;

namespace EnotoButebrodo
{
    public class TimersService : MonoBehaviour, ITimersService
    {
        private List<Timer> _timers = new List<Timer>(8);
        
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
            foreach (Timer timer in _timers)
            {
                timer.UpdateTime(Time.deltaTime);
            }   
        }
    }
}