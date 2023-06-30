using Lyaguska.HUD;
using Lyaguska.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lyaguska.Services
{
    [CreateAssetMenu(menuName = "UI/UIElements")]
    public class UIElements : ScriptableObject
    {
        [SerializeField] private PauseScreen _pauseScreenPrefab;
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;
        [SerializeField] private TittleScreen _tittleScreenPrefab;
        [SerializeField] private PauseButton _pauseButtonPrefab;
        [FormerlySerializedAs("_distancePresenterPrefab")] 
        [SerializeField] private ScorePresenter scorePresenterPrefab;
        [SerializeField] private Transform _uiRoot;
        
        public PauseScreen PauseScreen => _pauseScreenPrefab;
        public GameOverScreen GameOverScreen => _gameOverScreenPrefab;
        public TittleScreen TittleScreen => _tittleScreenPrefab;
        public PauseButton PauseButton => _pauseButtonPrefab;
        public ScorePresenter ScorePresenter => scorePresenterPrefab;
        public Transform UIRoot => _uiRoot;
    }
}