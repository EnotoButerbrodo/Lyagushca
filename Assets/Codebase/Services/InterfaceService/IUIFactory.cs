using Lyaguska.HUD;
using Lyaguska.UI;

namespace Lyaguska.Services
{
    public interface IUIFactory
    {
        void Load();
        PauseScreen GetPauseScreen();
        TittleScreen GetTittleScreen();

        PauseButton GetPauseButton();
        GameOverScreen GetGameOverScreen();
        DistancePresenter GetDistancePresenter();
    }
}