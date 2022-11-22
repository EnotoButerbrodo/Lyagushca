using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        GameConfigBind();
        ControlsBind();
    }

    private void GameConfigBind()
    {
        Container
                    .Bind<GameConfig>()
                    .FromInstance(_gameConfig)
                    .AsSingle();
    }

    private void ControlsBind()
    {
        Container
            .Bind<Controls>()
            .FromInstance(new Controls())
            .AsSingle()
            .NonLazy();
    }
}
