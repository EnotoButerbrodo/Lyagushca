using Lyaguska.Services;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class InterfaceInstaller : MonoInstaller
    {
        [SerializeField] private UIElements _elements;

        public override void InstallBindings()
        {
            BindInterface();
        }

        private void BindInterface()
        {
            UIFactory _uiFactory = new UIFactory(Container, _elements);

            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .FromInstance(_uiFactory)
                .AsSingle();
            
            InterfaceService interfaceService = new InterfaceService(_uiFactory);

            Container
                .Bind<IInterfaceService>()
                .To<InterfaceService>()
                .FromInstance(interfaceService)
                .AsSingle();
        }
    }
}