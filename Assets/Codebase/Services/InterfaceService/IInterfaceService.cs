using System;

namespace Lyaguska.Services
{
    public interface IInterfaceService
    {
        void ShowPauseScreen();
        void ShowTittleScreen();
        void ShowGameOverScreen(int distance, int highScore);
        void ShowUI();
        void HideUI();
    }
}