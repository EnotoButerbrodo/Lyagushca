using System;
using Lyaguska.UI;
using UnityEngine;
using Screen = Lyaguska.UI.Screen;

namespace Lyaguska.Services
{
    public class ScreenService : MonoBehaviour, IScreenService
    {
        [SerializeField] private Screen _pauseScreen;

        public void ShowPauseScreen()
        {
            _pauseScreen.Show();
        }
    }
}