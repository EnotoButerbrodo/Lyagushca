using Cinemachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class ActorInstaller : MonoInstaller
    {
        [SerializeField] private Actor _defaultActor;
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private Vector2 _startPoint;

        public override void InstallBindings()
        {
            var player = BindGameActor();
            var camera = BindCamera();
            camera.Follow = player.transform;
        }

        private Actor BindGameActor()
        {
            var defaultActorInstance = Container.InstantiatePrefabForComponent<Actor>(_defaultActor
                , _startPoint
                , Quaternion.identity,
                null);
            
            Container
                .Bind<Actor>()
                .FromInstance(defaultActorInstance)
                .AsSingle()
                .NonLazy();

            return defaultActorInstance;
        }

        private CinemachineVirtualCamera BindCamera()
        {
            var camera = Container.InstantiatePrefabForComponent<CinemachineVirtualCamera>(_camera);
            Camera.main.AddComponent<CinemachineBrain>();

            return camera;
        }

    }
}
