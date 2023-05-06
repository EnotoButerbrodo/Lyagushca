using System.Runtime.InteropServices;
using Lyaguska.Bootstrap;
using Lyaguska.Services;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Lyaguska.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Inject] private IInterfaceService _interfaceService;
        [Inject] private IPauseService _pauseService;
        
        
        private void OnEnable()
        {
            _button.onClick.AddListener(PauseGame);
        }

        private void PauseGame()
        {
            _pauseService.Pause();
            _interfaceService.ShowPauseScreen();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PauseGame);
        }
    }
}