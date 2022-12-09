using Lyaguska.LevelGeneration;
using System;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core
{
    public class Game : MonoBehaviour
    {
        [Inject] private LevelGenerationConfig _generationConfig;
        [Inject] private IDistanceCounter _distanceCounter;

        [SerializeField] private Transform _startPosition;
        private ILevelGenerator _levelGenerator;

        private void Awake()
        {
            _levelGenerator = new LevelGenerator(_generationConfig, _startPosition.position);

            _distanceCounter.DistanceChanged += OnDistanceChanged;
            StartNewGame();
        }

        private void OnDistanceChanged(float distance)
        {
            if(distance % 10 == 0)
            {
                _levelGenerator.PlaceNewChunk(distance);
            }
        }

        public void StartNewGame() 
        {
            _levelGenerator.SpawnStart();
        }

        /*
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private CinemachineCameraOffset _cameraOffset;

        [Inject] private GameActor _player;

        private CinemachineFramingTransposer _cameraTransposer;
        private Vector3 _playerStartPosition;
        private Vector3 _cameraStartPosition;

        private void Start()
        {
            _playerStartPosition = _player.transform.position;
            _cameraStartPosition = _camera.transform.position;
            _cameraTransposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
        private void OnEnable()
        {
            _player.Dead += OnPlayerDead;
            _gameOverScreen.ReloadButtonClick += StartNewGame;
        }

        private void OnDisable()
        {
            _player.Dead -= OnPlayerDead;
            _gameOverScreen.ReloadButtonClick -= StartNewGame;
        }

        private void OnPlayerDead()
        {
            //�������� ����� ������
            _gameOverScreen.Show(_scoreCounter.Score);
            Time.timeScale = 0;
        }

        private void StartNewGame()
        {
            _camera.enabled = false;
            _player.ResetGameActor();
            _player.transform.position = _playerStartPosition;

            _cameraTransposer.ForceCameraPosition(_cameraStartPosition, Quaternion.identity);

            _gameOverScreen.Hide();
            _camera.enabled = true;
            _scoreCounter.Reset();
            Time.timeScale = 1;
        }
        */
    }
}