using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class InterfaceInstaller : MonoInstaller
    {
        [SerializeField] private ScreenService _interface;
        public override void InstallBindings()
        {
            CreateInterface();
        }

        private void CreateInterface()
        {
            ScreenService screenService = Container.InstantiatePrefabForComponent<ScreenService>(_interface);

            Container
                .Bind<IScreenService>()
                .To<ScreenService>()
                .FromInstance(screenService)
                .AsSingle();
        }
        
    }
}