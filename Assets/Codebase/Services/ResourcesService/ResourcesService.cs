using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Screen = Lyaguska.UI.Screen;

namespace Lyaguska.Services
{
    public class ResourcesService : IResourcesService
    {
        private const string ScreensPath = "UI/Screens";
        private const string UIRootPath = "UI/Root";
        
        private Dictionary<Type, Screen> _screens;
        private GameObject _uiRoot;
        
        public void Load()
        {
            _screens = Resources.LoadAll<Screen>(ScreensPath)
                .ToDictionary(x => x.GetType(), x => x);

            _uiRoot = Resources.Load<GameObject>(UIRootPath);
        }

        public TScreen GetScreen<TScreen>()
            where TScreen : Screen =>
            _screens[typeof(TScreen)] as TScreen;

        public GameObject GetUIRoot() 
            => _uiRoot;
    }
}