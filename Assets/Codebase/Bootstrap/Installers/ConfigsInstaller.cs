using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindConfigs();   
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