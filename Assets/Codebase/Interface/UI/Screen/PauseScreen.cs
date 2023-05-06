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

        [Inject] private IPauseService _pauseService;

        protected override void OnAwaked()
        {
            _resumeButton.onClick.AddListener(OnResume);
        }

        protected override void OnShow()
        {
            _resumeButton.Select();
        }

        protected override void OnDestroyed()
        {
            _resumeButton.onClick.RemoveListener(OnResume);
        }

        private void OnResume()
        {
            Hide();
            _pauseService.Resume();
        }
    }
}