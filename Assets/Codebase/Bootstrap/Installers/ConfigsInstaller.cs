using EnotoButerbrodo.LevelGeneration;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private ChunksCollection _chunksCollection;
        public override void InstallBindings()
        {
            BindChunksCollection();
            BindConfigs();   
        }

        private void BindChunksCollection()
        {
            Container
                .Bind<ChunksCollection>()
                .FromInstance(_chunksCollection)
                .AsSingle();
        }

        private void BindConfigs()
        {
            foreach (ScriptableObject config in Resources.LoadAll<ScriptableObject>("Configs"))
            {
                Container
                    .Bind(config.GetType())
                    .FromInstance(config)
                    .AsSingle();
            }
        }

     
    }
}