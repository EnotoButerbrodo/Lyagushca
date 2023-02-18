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
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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