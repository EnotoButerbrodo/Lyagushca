using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class DistanceCounterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindDistanceCounter();
        }


        private void BindDistanceCounter()
        {
            Container
                .Bind<IDistanceCounter>()
                .To<DistanceCounter>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}