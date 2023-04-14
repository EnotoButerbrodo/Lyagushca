using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.Services
{
    public class PauseService : IPauseService
    {
        public event Action Paused;
        public event Action Resumed;
        
        public PauseService()
        {
            _pausableServices = new List<IPauseable>(8);
        }
        
        public bool IsPaused { get; private set; }
        private List<IPauseable> _pausableServices;
        
        public void Register(IPauseable service) 
            => _pausableServices.Add(service);

        public void Unregister(IPauseable service) 
            => _pausableServices.Remove(service);

        public void Pause()
        {
            IsPaused = true;
            _pausableServices.ForEach(x => x.Pause());
            Paused?.Invoke();
        }

        public void Resume()
        {
            IsPaused = false;
            _pausableServices.ForEach(x => x.Resume());
            Resumed?.Invoke();
        }
    }
}