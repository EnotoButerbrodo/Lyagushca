using System;
using Codebase.Services.JumpComboService;
using Lyaguska.Services;
using UnityEngine;

namespace Codebase.Services.ScoreService
{
    public class ScoreConfig : ScriptableObject
    {
        
    }
    public class ScoreService
    {
        public int Score { get; private set; }
        public int ScoreBuffer { get; private set; }

        public ScoreService(IJumpComboService jumpCombo, IDistanceCountService distanceCount)
        {
            _jumpCombo = jumpCombo;
            _distanceCount = distanceCount;
        }

        public event Action<int> ScoreChanged;
        public event Action<int> ScoreBufferChanged;
        
        
        private readonly IJumpComboService _jumpCombo;
        private readonly IDistanceCountService _distanceCount;


        private float _jumpPosition;
        
        public void SetJump()
        {
            //Значение очков в первую очередь от длины прыжка
            //Очков комбо
            _jumpPosition = _distanceCount.Distance;
            _jumpCombo.SetJump();
        }

        public void SetLand()
        {
            var landDistance = _distanceCount.Distance;
            var jumpDistance = landDistance - _jumpPosition;
            _jumpCombo.SetLand();

            Score = Mathf.CeilToInt(jumpDistance) * _jumpCombo.Combo;
            Debug.Log(Score);

        }
    }
}