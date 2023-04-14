using Lyaguska.Bootstrap;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Zenject;

namespace Lyaguska.UI
{
    public class GameOverScreen : Screen
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private TextMeshProUGUI _distanceText;
        [Inject] private IGame _game;


        protected override void OnAwaked()
        {
            _resetButton.onClick.AddListener(OnReset);
        }

        protected override void OnShow()
        {
            _resetButton.Select();
        }

        private void OnDestroy()
        {
            _resetButton.onClick.RemoveListener(OnReset);
        }

        private void OnReset()
        {
            _game.ResetGame();
            Hide();
        }

        public void Show(int distance = 0, int highScore = 0)
        {
            _distanceText.text = distance.ToString();
            Debug.Log(highScore);
            base.Show();
        }
    }
}