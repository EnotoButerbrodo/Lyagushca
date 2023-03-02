using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.Services
{
    public class PauseService : IPauseService
    {
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
            Time.timeScale = 0;
            IsPaused = true;
            _pausableServices.ForEach(x => x.Pause());
        }

        public void Resume()
        {
            Time.timeScale = 1;
            IsPaused = false;
            _pausableServices.ForEach(x => x.Resume());
        }
    }
}