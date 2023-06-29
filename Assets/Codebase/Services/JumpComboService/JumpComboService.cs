using System;
using EnotoButebrodo;
using Lyaguska.Services;
using UnityEngine;

namespace Codebase.Services.JumpComboService
{
    public class JumpComboService : IJumpComboService
    {
        public event Action<int> ComboChanged;
        public event Action<int> ComboCleared; 
        public float ComboClearTime = 5f;
        public int Combo 
        {
            get => _combo;
            set
            {
                _combo = value;
                ComboChanged?.Invoke(_combo);
            }
        }
        
        private int _combo;
        private readonly ITimersService _timersService;
        private readonly JumpsConfig _jumpsConfig;
        private Timer _timer;

        public JumpComboService(ITimersService timersService
            , JumpsConfig jumpsConfig)
        {
            _timersService = timersService;
            _jumpsConfig = jumpsConfig;
            _timer = _timersService.GetTimer();
            _timer.Finished += OnComboTimerFinished;
        }

        public void SetJump()
        {
            _timer.Stop();
        }

        public void SetLand()
        {
            Combo++;
            _timer.Stop();
            _timer.Start(_jumpsConfig.ComboClearTime);

            Debug.Log("Combo " + Combo);
        }

        public void Reset()
        {
            ClearCombo();
        }

        private void OnComboTimerFinished(TimerEventArgs obj)
        {
            ClearCombo();
        }

        private void ClearCombo()
        {
            int lastCombo = Combo;
            Combo = 0;
            ComboCleared?.Invoke(lastCombo);
            Debug.Log("Cleared");
        }
    }
}