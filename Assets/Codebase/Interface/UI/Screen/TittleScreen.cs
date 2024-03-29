﻿using Lyaguska.Bootstrap;
using Lyaguska.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Lyaguska.UI
{
    public class TittleScreen : Screen
    {
        [SerializeField] private Button _startGameButton;
        [Inject] private GameStateMachine _stateMachine;
        protected override void OnAwaked()
        {
            _startGameButton.onClick.AddListener(OnStartGame);
            
        }

        protected override void OnShow()
        {
            _startGameButton.Select();
        }
        
        private void OnStartGame()
        {
            _stateMachine.Enter<GameLoopState>();
            Hide();
        }
    }
}