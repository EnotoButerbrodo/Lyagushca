using System;
using Codebase.Services.JumpComboService;
using Lyaguska.Services;
using UnityEngine;

namespace Codebase.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        public int Score { get; private set; }
        public int ScoreBuffer { get; private set; }

        public ScoreService(IJumpComboService jumpCombo
            , IDistanceCountService distanceCount
            , ScoreConfig scoreConfig)
        {
            _jumpCombo = jumpCombo;
            _distanceCount = distanceCount;
            _scoreConfig = scoreConfig;
        }

        public event Action<int> ScoreChanged;
        public event Action<int> ScoreBufferChanged;
        
        
        private readonly IJumpComboService _jumpCombo;
        private readonly IDistanceCountService _distanceCount;
        private readonly ScoreConfig _scoreConfig;


        private float _jumpPosition;
        
        public void SetJump()
        {
            _jumpPosition = _distanceCount.Distance;
            _jumpCombo.SetJump();
        }

        public void SetLand()
        {
            var landDistance = _distanceCount.Distance;
            var jumpDistance = landDistance - _jumpPosition - _scoreConfig.MinDistanceForScore;

            if (jumpDistance <= 0)
            {
                _jumpCombo.ClearCombo();
                return;
            }
                

            _jumpCombo.SetLand();
            
            Score = Mathf.CeilToInt(jumpDistance) * _jumpCombo.Combo;
            Debug.Log(Score);

        }

        public void Reset()
        {
            _jumpPosition = 0;
        }
    }
}