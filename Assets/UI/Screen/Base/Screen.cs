using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour
{
    public UnityEvent Showed;
    public UnityEvent Hided;

    [SerializeField] private bool _hideOnAwake;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        if (_hideOnAwake)
        {
            Hide();
        }
        
    }
    public virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        Showed?.Invoke();
    }

    public virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        Hided?.Invoke();
    }

}
