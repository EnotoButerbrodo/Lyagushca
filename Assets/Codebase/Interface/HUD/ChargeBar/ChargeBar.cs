using System;
using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Lyaguska.HUD
{
    public class ChargeBar : MonoBehaviour, IResetable
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _chargeFillImage;
        [SerializeField] private Image _chargedIndicatorImage;
        [SerializeField] private Color _startColor;
        [SerializeField] private Color _endColor;
        [SerializeField] private bool _hideInAwake = true;


        private void Awake()
        {
            if(_hideInAwake)
                Hide();
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
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
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