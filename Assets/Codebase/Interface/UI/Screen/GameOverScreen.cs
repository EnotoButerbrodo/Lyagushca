using Lyaguska.Bootstrap;
using Lyaguska.Services;
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
        [Inject] private GameStateMachine _stateMachine;


        protected override void OnAwaked()
        {
            _resetButton.onClick.AddListener(OnResetButtonPressed);
        }

        protected override void OnShow()
        {
            _resetButton.Select();
        }

        private void OnDestroy()
        {
            _resetButton.onClick.RemoveListener(OnResetButtonPressed);
        }

        private void OnResetButtonPressed()
        {
            _stateMachine.Enter<GameResetState>();
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