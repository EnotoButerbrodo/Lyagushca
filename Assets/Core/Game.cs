using Lyaguska.LevelGeneration;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core
{
    public class Game : MonoBehaviour
    {
        [Inject] private LevelGenerationConfig _generationConfig;
        [Inject] private IDistanceCounter _distanceCounter;

        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _generationStartPosition;
        [SerializeField] private Transform _chunksParent;
        
        private ILevelGenerator _levelGenerator;
        private float _lastDistance;

        private void Awake()
        {
            _levelGenerator = new LevelGenerator(_generationConfig, _generationStartPosition.position, _chunksParent);
            _distanceCounter.DistanceChanged += OnDistanceChanged;

            StartNewGame();
        }

        private void OnDistanceChanged(float distance)
        {
            if(distance > 1 && distance - _lastDistance > 10)
            {
                _levelGenerator.PlaceNewChunk(distance);
                _lastDistance = distance;
            }
        }

        public void StartNewGame() 
        {
            _levelGenerator.SpawnStartChunk();
            for (int i = 0; i < 5; i++)
            {
                _levelGenerator.PlaceNewChunk(0);
            }
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
            //Показать экран смерти
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