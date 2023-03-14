using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Lyaguska.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        [SerializeField] private bool _hideInAwake = true;
        [SerializeField] private float _showTime = 0.1f;
        [SerializeField] private float _hideTime = 0.1f;
        
        private CanvasGroup _canvasGroup;
        private Tween _currentTween;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            if (_hideInAwake)
                DisableGameObject();

            OnAwaked();
        }

        public void Show()
        {
            EnableGameObject();
            _currentTween?.Kill();
            _currentTween = DOTween.To(ChangeScreenAlphaTween
                , 0
                , 1
                , _showTime);

            OnShow();
        }
        
        private void EnableGameObject()
            => gameObject.SetActive(true);

        public void Hide()
        {
            _currentTween?.Kill();
            _currentTween = DOTween.To(ChangeScreenAlphaTween
                , startValue: 1
                , endValue: 0
                , duration: _hideTime)
                .OnComplete(DisableGameObject);
            
            OnHide();
        }

        private void DisableGameObject() 
            => gameObject.SetActive(false);

        private void ChangeScreenAlphaTween(float alpha)
            => _canvasGroup.alpha = alpha;

       

        
        protected virtual void OnShow() {}

        protected virtual void OnHide() {}
        
        protected virtual void OnAwaked()
        {
            return;
        }

        protected virtual void OnDestroyed()
        {
            return;
        }
        
        private void OnDestroy()
        {
            OnDestroyed();
        }
    }
}