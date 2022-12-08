using Lyaguska.LevelGeneration;
using UnityEngine;
using Zenject;

public class LevelGenerationInstaller : MonoInstaller
{
    [SerializeField] private LevelGenerationConfig _levelGenerationConfig;
    public override void InstallBindings()
    {
        BindChunkGenerator();
    }

    private void BindChunkGenerator()
    {
        var chunkGenerator = Container.InstantiateComponentOnNewGameObject <DefaultChunkGenerator>();
        Container
            .Bind<IChunkGenerator>()
            .FromInstance(chunkGenerator)
            .AsSingle();
    }
}