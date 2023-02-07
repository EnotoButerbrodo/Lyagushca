using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;


namespace Lyaguska.HUD
{
    [RequireComponent(typeof(CanvasGroup))]

    public class ChargeBar : MonoBehaviour, IResetable
    {
        [SerializeField] private Image _chargeFillImage;
        private CanvasGroup _elementCanvasGroup;

        private void Awake()
        {
            _elementCanvasGroup = GetComponent<CanvasGroup>();
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
            _chargeFillImage.fillAmount = percent;
        }

        public void Reset()
        {
            _chargeFillImage.fillAmount = 0;
        }
    }

}