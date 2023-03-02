using Lyaguska.Bootstrap;
using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lyaguska.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ScreenService _screenService;
        [Inject] private IGame _game;
        
        
        private void OnEnable()
        {
            _button.onClick.AddListener(PauseGame);
        }

        private void PauseGame()
        {
            _game.Pause();
            _screenService.ShowPauseScreen();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PauseGame);
        }
    }
}