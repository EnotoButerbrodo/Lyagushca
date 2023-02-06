using System.Globalization;
using Lyaguska.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.UI
{
    public class DistancePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _format = "0.0";
        [Inject] private IDistanceCountService _distanceCount;

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
            _text.text = Mathf.FloorToInt(distance).ToString(_format, CultureInfo.InvariantCulture);
        } 
    }
}