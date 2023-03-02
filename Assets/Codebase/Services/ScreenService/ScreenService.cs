using System;
using Lyaguska.UI;
using UnityEngine;
using Screen = Lyaguska.UI.Screen;

namespace Lyaguska.Services
{
    public class ScreenService : MonoBehaviour, IScreenService
    {
        [SerializeField] private Screen _pauseScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private TittleScreen _tittleScreen;
        public void ShowPauseScreen() 
            => _pauseScreen.Show();

        public void ShowGameOverScreen(float distance) 
            => _gameOverScreen.Show(distance);

        public void ShowTittleScreen()
            => _tittleScreen.Show();
    }
}