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
        [SerializeField] private string _format = "0.0";
        
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

        private void OnDistanceChanged(float distance)
        {
            int normalizedDistance = Mathf.FloorToInt(distance);
            if(_lastDistance == normalizedDistance)
                return;

            _lastDistance = normalizedDistance;
            
            _text.text = normalizedDistance.ToString(_format, CultureInfo.InvariantCulture);
        } 
    }
}