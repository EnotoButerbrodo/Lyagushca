using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.UI
{
    public class UIFactory : IUIFactory
    {
        private IResourcesService _resources;
        private Transform _uiRoot;
        
        public Screen CreatePauseScreen()
        {
            var pause = _resources.GetScreen<Screen>();
            return GameObject.Instantiate(pause, _uiRoot);
        }

        public void CreateUIRoot() 
            => _uiRoot = GameObject.Instantiate(_resources.GetUIRoot().transform);
    }
}