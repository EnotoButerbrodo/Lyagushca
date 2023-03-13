using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Lyaguska.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ChargeBar : MonoBehaviour, IResetable
    {
        [SerializeField] private Image _chargeFillImage;
        [SerializeField] private Image _chargedIndicatorImage;
        [SerializeField] private Color _startColor;
        [SerializeField] private Color _endColor;
        
        private CanvasGroup _elementCanvasGroup;

        private void Awake()
        {
            _elementCanvasGroup = GetComponent<CanvasGroup>();
        }

        public void ShowFullChargeIndicator()
        {
            _chargedIndicatorImage.enabled = true;
        }

        public void HideFullChargeIndicator()
        {
            _chargedIndicatorImage.enabled = false;
        }
        public void Show()
        {
            _elementCanvasGroup.alpha = 1;
        }

        public void ShowHalf()
        {
            _elementCanvasGroup.alpha = .5f;
        }

        public void Hide()
        {
            _elementCanvasGroup.alpha = 0;
        }

        public void SetFillPercent(float percent)
        {
            _chargeFillImage.color = Color.Lerp(_startColor, _endColor, percent);
            _chargeFillImage.fillAmount = percent;
        }

        public void Reset()
        {
            _chargeFillImage.fillAmount = 0;
        }
    }

}