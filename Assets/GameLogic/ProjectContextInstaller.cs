﻿using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        GameConfigBind();
        ControlsBind();
        BindTimer();
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
