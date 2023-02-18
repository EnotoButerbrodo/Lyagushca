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

        private void OnDestroy()
        {
            _resetButton.onClick.RemoveListener(OnReset);
        }

        private void OnReset()
        {
            _game.Reset();
            Hide();
        }

        public void Show(float distance = 0)
        {
            _distanceText.text =  Mathf.FloorToInt(distance).ToString();
            base.Show();
        }
    }
}