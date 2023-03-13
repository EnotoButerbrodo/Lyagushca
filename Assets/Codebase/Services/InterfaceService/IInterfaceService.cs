using System;
using Lyaguska.UI;

namespace Lyaguska.Services
{
    public interface IInterfaceService
    {
        void ShowPauseScreen();
        void ShowTittleScreen();
        void ShowGameOverScreen(float distance);
        void ShowUI();
        void HideUI();
    }
}