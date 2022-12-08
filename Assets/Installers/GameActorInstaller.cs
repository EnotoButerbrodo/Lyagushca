using Cinemachine;
using Lyaguska.Core;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameActorInstaller : MonoInstaller
{
    [SerializeField] private Actor _defaultActor;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;

    public override void InstallBindings()
    {
        BindJumpForceCharger();
        var player = BindGameActor();
        var camera = BindCamera();

        camera.Follow = player.transform;
        BindDistanceCounter();
    }

    private void BindDistanceCounter()
    {
        var distanceCounter = Container.InstantiateComponentOnNewGameObject<DistanceCounter>();

        Container
            .BindInterfacesAndSelfTo<DistanceCounter>()
            .FromInstance(distanceCounter)
            .AsSingle();
    }

    private Actor BindGameActor()
    {
        var defaultActorInstance = Container.InstantiatePrefabForComponent<Actor>(_defaultActor
                                                                  , _startPoint.position
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

    private void BindJumpForceCharger()
    {
        
        var jumpForceChargerInstance =
            Container
                .InstantiateComponentOnNewGameObject<JumpForceCharger>();

        Container
            .Bind<IJumpForceCharger>()
            .To<JumpForceCharger>()
            .FromInstance(jumpForceChargerInstance)
            .AsSingle();
    }

    private void BindJumpForceAutoCharger()
    {
        var jumpForceAutoCharger =
            Container
                .InstantiateComponentOnNewGameObject<JumpForceAutoCharger>();

        Container
            .Bind<JumpForceAutoCharger>() 
            .FromInstance(jumpForceAutoCharger);
    }
}

