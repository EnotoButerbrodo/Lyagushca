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
        [Inject] private IPauseService _pauseService;
        private GameStateMachine _stateMachine;

        public bool IsPaused => _pauseService.IsPaused;
        private void Start()
        {
            _stateMachine = new GameStateMachine(_container);
            _stateMachine.Enter<TittleScreenState>();
        }

        public void StartGame()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        public void Pause()
        {
            _pauseService.Pause();
        }

        public void Resume()
        {
            _pauseService.Resume();
        }

        public void ResetGame()
        {
            _stateMachine.Enter<GameResetState>();
        }

        private void Update()
        {
            _stateMachine.UpdateStates();
        }
    }
}