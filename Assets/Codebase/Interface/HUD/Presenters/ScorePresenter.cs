using System;
using Codebase.Services.JumpComboService;
using Codebase.Services.ScoreService;
using Lyaguska.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Lyaguska.HUD
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _scoreBufferText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        
        [Inject] private IScoreService _scoreService;
        [Inject] private IPauseService _pauseService;
        [Inject] private IProgressService _progress;


        private void OnScoreChanged(int score)
        {
            int combo = _scoreService.JumpCombo.Combo;
            _scoreText.enabled = score > 0;
            _scoreText.SetText($"{score} X{combo}");
        }

        private void OnPause()
        {
            _highScoreText.SetText("High: {0}", _progress.GetHighScore());
            _highScoreText.enabled = true;
        }

        private void Awake()
        {
            _highScoreText.enabled = false;
            _scoreText.enabled = false;

        }

        private void OnEnable()
        {
            _scoreService.ScoreChanged += OnScoreChanged;
            _pauseService.Paused += OnPause;
            _pauseService.Resumed += OnResume;
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= OnScoreChanged;
            _pauseService.Paused -= OnPause;
            _pauseService.Resumed -= OnResume;
        }

        public void Hide()
        {
            _scoreText.enabled = false;
            _highScoreText.enabled = false;
        }

        private void OnResume()
        {
            _highScoreText.enabled = false;
        }
    }
}