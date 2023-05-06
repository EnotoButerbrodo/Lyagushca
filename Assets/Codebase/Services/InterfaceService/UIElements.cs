using Lyaguska.HUD;
using Lyaguska.UI;
using UnityEngine;

namespace Lyaguska.Services
{
    [CreateAssetMenu(menuName = "UI/UIElements")]
    public class UIElements : ScriptableObject
    {
        [SerializeField] private PauseScreen _pauseScreenPrefab;
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;
        [SerializeField] private TittleScreen _tittleScreenPrefab;
        [SerializeField] private PauseButton _pauseButtonPrefab;
        [SerializeField] private DistancePresenter _distancePresenterPrefab;
        [SerializeField] private Transform _uiRoot;
        
        public PauseScreen PauseScreen => _pauseScreenPrefab;
        public GameOverScreen GameOverScreen => _gameOverScreenPrefab;
        public TittleScreen TittleScreen => _tittleScreenPrefab;
        public PauseButton PauseButton => _pauseButtonPrefab;
        public DistancePresenter DistancePresenter => _distancePresenterPrefab;
        public Transform UIRoot => _uiRoot;
    }
}