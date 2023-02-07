using System;
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
            
        }

        public void Resume()
        {
            
        }

        private void Update()
        {
            _stateMachine.UpdateStates();
        }
    }
}