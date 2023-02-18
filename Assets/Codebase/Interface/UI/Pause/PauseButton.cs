using Lyaguska.Bootstrap;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lyaguska.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Inject] private IGame _game;

        private bool _isPaused;
        private void OnEnable()
        {
            _button.onClick.AddListener(PauseGame);
        }

        private void PauseGame()
        {
            _game.Pause();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PauseGame);
        }
    }
}