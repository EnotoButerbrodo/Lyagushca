using Lyaguska.Core;
using UnityEngine;
using Zenject;
using Lyaguska.LevelGeneration;

public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private JumpsConfig _gameConfig;
    [SerializeField] private LevelGenerationConfig _levelGenerationConfig;

    public override void InstallBindings()
    {
        GameConfigBind();
        LevelGenerationConfigBind();
        ControlsBind();
        BindTimer();
    }

    private void LevelGenerationConfigBind()
    {
        Container
                    .Bind<LevelGenerationConfig>()
                    .FromInstance(_levelGenerationConfig)
                    .AsSingle();
    }

    private void BindTimer()
    {
        Container
            .BindInterfacesAndSelfTo<Timer>()
            .FromInstance(new Timer())
            .AsTransient();

    }

    private void GameConfigBind()
    {
        Container
                    .Bind<JumpsConfig>()
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
