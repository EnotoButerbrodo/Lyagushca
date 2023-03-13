using System;
using Lyaguska.UI;
using UnityEngine;
using Screen = Lyaguska.UI.Screen;

namespace Lyaguska.Services
{
    public class InterfaceService : MonoBehaviour, IInterfaceService
    {
        [SerializeField] private Screen _pauseScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private TittleScreen _tittleScreen;
        [SerializeField] private PauseButton _pauseButton;

        public void ShowUI()
        {
            _pauseButton.gameObject.SetActive(true);
        }

        public void HideUI()
        {
            _pauseButton.gameObject.SetActive(false);
        }
        public void ShowPauseScreen() 
            => _pauseScreen.Show();

        public void ShowGameOverScreen(float distance) 
            => _gameOverScreen.Show(distance);

        public void ShowTittleScreen()
            => _tittleScreen.Show();
    }
}