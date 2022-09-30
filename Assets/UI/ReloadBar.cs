using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ReloadBar : MonoBehaviour
{
    [SerializeField] private Image _reloadFillImage;
    private CanvasGroup _elementCanvasGroup;

    private void Awake()
    {
        _elementCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        _elementCanvasGroup.alpha = 1;
    }

    public void Hide()
    {
        _elementCanvasGroup.alpha = 0;
    }

    public void SetFillPercent(float percent)
    {
        _reloadFillImage.fillAmount = percent;
    }

    public void Reset()
    {
        _reloadFillImage.fillAmount = 0;
    }
}
