using Lyaguska.Core;
using UnityEngine;
using Zenject;
using EnotoButerbrodo.LevelGeneration;

namespace Lyaguska.Bootstrap.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private JumpsConfig _gameConfig;
        [SerializeField] private LevelGenerationConfig _levelGenerationConfig;
        [SerializeField] private ChunksCollection _chunksCollection;

        public override void InstallBindings()
        {
            BindJumpConfig();
            BindLevelGenerationConfig();
            BindChunksCollection();
        }

        private void BindChunksCollection()
        {
            Container
                .Bind<ChunksCollection>()
                .FromInstance(_chunksCollection)
                .AsSingle();
        }

        private void BindLevelGenerationConfig()
        {
            Container
                .Bind<LevelGenerationConfig>()
                .FromInstance(_levelGenerationConfig)
                .AsSingle();
        }



        private void BindJumpConfig()
        {
            Container
                .Bind<JumpsConfig>()
                .FromInstance(_gameConfig)
                .AsSingle();
        }


    }
}
