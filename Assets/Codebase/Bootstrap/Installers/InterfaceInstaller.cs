using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class InterfaceInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceService _interface;
        public override void InstallBindings()
        {
            CreateInterface();
        }

        private void CreateInterface()
        {
            InterfaceService interfaceService = Container.InstantiatePrefabForComponent<InterfaceService>(_interface);

            Container
                .Bind<IInterfaceService>()
                .To<InterfaceService>()
                .FromInstance(interfaceService)
                .AsSingle();
        }
        
    }
}