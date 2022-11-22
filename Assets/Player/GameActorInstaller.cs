using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameActorInstaller : MonoInstaller
{
    [SerializeField] private GameActor _defaultActor;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;

    public override void InstallBindings()
    {
        JumpForceAutoChargerBind();
        JumpForceChargerBind();
        GameActorBind();
    }

    private void GameActorBind()
    {
        var defaultActorInstance = Container.InstantiatePrefabForComponent<GameActor>(_defaultActor
                                                                  , _startPoint.position
                                                                  , Quaternion.identity,
                                                                  null);
        Container
            .Bind<GameActor>()
            .FromInstance(defaultActorInstance)
            .AsSingle()
            .NonLazy();

        _camera.Follow = defaultActorInstance.transform;
    }

    private void JumpForceChargerBind()
    {
        
        var jumpForceChargerInstance =
            Container
                .InstantiateComponentOnNewGameObject<JumpForceCharger>();

        Container
            .Bind<JumpForceCharger>()
            .FromInstance(jumpForceChargerInstance)
            .AsSingle();
    }

    private void JumpForceAutoChargerBind()
    {
        var jumpForceAutoCharger =
            Container
                .InstantiateComponentOnNewGameObject<JumpForceAutoCharger>();

        Container
            .Bind<JumpForceAutoCharger>()
            .FromInstance(jumpForceAutoCharger);
    }
}

