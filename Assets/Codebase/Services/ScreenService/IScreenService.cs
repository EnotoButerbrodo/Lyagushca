﻿using System;
using Lyaguska.UI;

namespace Lyaguska.Services
{
    public interface IScreenService
    {
        void ShowPauseScreen();
        void ShowGameOverScreen(float distance);
    }
}