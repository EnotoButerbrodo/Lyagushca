using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameResetService
{
    private List<IResetable> _resetableComponents;
    private DiContainer _container;

    public GameResetService(DiContainer container)
    {
        _container = container;
        _resetableComponents = GetResetComponents();
    }

    public void Reset()
    {
        foreach (var component in _resetableComponents)
        {
            component.Reset();
        }
    }


    private List<IResetable> GetResetComponents()
        => _container.ResolveAll<IResetable>();

}
public class Game : MonoBehaviour
{
    private GameActor _player;

    private void Awake()
    {
        StartNewGame();
    }
    public void StartNewGame()
    {

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


