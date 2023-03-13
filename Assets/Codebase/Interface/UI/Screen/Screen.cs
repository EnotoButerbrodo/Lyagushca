using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lyaguska.UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private bool _hideInAwake = true;

        public void Show()
        { 
            gameObject.SetActive(true);
            OnShow();
        }

        protected virtual void OnShow() {}
        protected virtual void OnHide() {}
        

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }
        
        private void Awake()
        {
            if (_hideInAwake)
                Hide();

            OnAwaked();
        }

        private void OnDestroy()
        {
            OnDestroyed();
        }
        
        protected virtual void OnAwaked()
        {
            return;
        }

        protected virtual void OnDestroyed()
        {
            return;
        }
    }
}