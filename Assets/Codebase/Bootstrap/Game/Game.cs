using System;
using Lyaguska.Services;
using Lyaguska.UI;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap
{
    public class Game : MonoBehaviour, IGame
    {
        [Inject] private DiContainer _container;

        private GameStateMachine _stateMachine;
 
        private void Start()
        {
            _stateMachine = new GameStateMachine(_container);
            StartNewGame();
        }

        public void StartNewGame()
        {
            _stateMachine.Enter<LevelCreateState>();
        }

        public void Pause()
        {
            _stateMachine.Enter<PauseState>();
        }

        public void Resume()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        public void Reset()
        {
            _stateMachine.Enter<GameResetState>();
        }

        private void Update()
        {
            _stateMachine.UpdateStates();
        }
    }
}