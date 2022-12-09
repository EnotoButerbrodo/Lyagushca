using Lyaguska.LevelGeneration;
using UnityEngine;
using Zenject;

public class LevelGenerationInstaller : MonoInstaller
{
    [SerializeField] private LevelGenerationConfig _levelGenerationConfig;

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