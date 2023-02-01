using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lyaguska.UI
{
    public class GameOverScreen : Screen
    {
        public event UnityAction ReloadButtonClick
        {
            add { _reloadButton.onClick.AddListener(value); }
            remove { _reloadButton.onClick.RemoveListener(value); }
        }

        [SerializeField] private TextMeshProUGUI _scoreResultText;
        [SerializeField] private Button _reloadButton;

        public void Show(int score)
        {
            _scoreResultText.text = score.ToString();
            _reloadButton.enabled = true;
            Show();
        }

        public override void Hide()
        {
            base.Hide();
            _reloadButton.enabled = false;
        }

    }
}