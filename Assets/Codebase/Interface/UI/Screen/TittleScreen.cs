using UnityEngine;
using UnityEngine.UI;


namespace Lyaguska.UI
{
    public class TittleScreen : Screen
    {
        [SerializeField] private Button _startGameButton;

        protected override void OnAwaked()
        {
            _startGameButton.onClick.AddListener(Hide);
        }
    }
}