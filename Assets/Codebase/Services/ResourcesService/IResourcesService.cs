using UnityEngine;
using Screen = Lyaguska.UI.Screen;

namespace Lyaguska.Services
{
    public interface IResourcesService
    {
        void Load();

        TScreen GetScreen<TScreen>()
            where TScreen : Screen;

        GameObject GetUIRoot();
    }
}