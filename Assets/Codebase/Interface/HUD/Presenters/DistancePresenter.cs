using System.Globalization;
using Lyaguska.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Lyaguska.HUD
{
    public class DistancePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [Inject] private IDistanceCountService _distanceCount;
        private int _lastDistance = -1;

        private void OnEnable()
        {
            _distanceCount.DistanceChanged += OnDistanceChanged;
        }

        private void OnDisable()
        {
            _distanceCount.DistanceChanged -= OnDistanceChanged;
        }

        private void OnDistanceChanged(int distance)
        {
            _text.enabled = distance > 0;
            _text.text = distance.ToString();
        } 
    }
}