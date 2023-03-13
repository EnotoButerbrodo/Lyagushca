using Lyaguska.Bootstrap;
using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lyaguska.UI
{
    public class PauseScreen : Screen
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _resetButton;

        [Inject] private IGame _game;

        protected override void OnAwaked()
        {
            _resumeButton.onClick.AddListener(OnResume);
            _resetButton.onClick.AddListener(OnReset);
        }

        protected override void OnShow()
        {
            _resumeButton.Select();
        }

        private void OnReset()
        {
            Hide();
            _game.ResetGame();
        }

        protected override void OnDestroyed()
        {
            _resumeButton.onClick.RemoveListener(OnResume);
            _resetButton.onClick.RemoveListener(OnReset);
        }

        private void OnResume()
        {
            Hide();
            _game.Resume();
        }
    }
}