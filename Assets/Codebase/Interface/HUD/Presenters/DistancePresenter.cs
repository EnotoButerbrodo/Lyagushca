using Lyaguska.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Lyaguska.HUD
{
    public class DistancePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _highText;

        [Inject] private IDistanceCountService _distanceCount;
        [Inject] private IPauseService _pauseService;
        [Inject] private IProgressService _progress;


        private void Awake()
        {
            _highText.enabled = false;
        }

        private void OnEnable()
        {
            _distanceCount.DistanceChanged += OnDistanceChanged;
            _pauseService.Paused += OnPause;
            _pauseService.Resumed += OnResume;
        }

        private void OnDisable()
        {
            _distanceCount.DistanceChanged -= OnDistanceChanged;
            _pauseService.Paused -= OnPause;
            _pauseService.Resumed -= OnResume;
        }

        public void Hide()
        {
            _text.enabled = false;
            _highText.enabled = false;
        }

        private void OnPause()
        {
            _highText.text = "High: " + _progress.GetHighScore();
            _highText.enabled = true;
        }

        private void OnResume()
        {
            _highText.enabled = false;
        }

        private void OnDistanceChanged(int distance)
        {
            _text.enabled = distance > 0;
            _text.text = distance.ToString();
        } 
    }
}