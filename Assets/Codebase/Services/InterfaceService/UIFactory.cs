using Lyaguska.HUD;
using Lyaguska.UI;
using UnityEngine;
using Zenject;

namespace Lyaguska.Services
{
    public class UIFactory : IUIFactory
    {
        private DiContainer _container;
        private UIElements _elements;

        public UIFactory(DiContainer container, UIElements elements)
        {
            _container = container;
            _elements = elements;
        }

        private PauseScreen _pauseScreen;
        private GameOverScreen _gameOverScreen;
        private TittleScreen _tittleScreen;
        private PauseButton _pauseButton;
        private DistancePresenter _distancePresenter;

        public void Load()
        {
            var uiRoot = Object.Instantiate(_elements.UIRoot);
            
            _pauseScreen = _container
                .InstantiatePrefabForComponent<PauseScreen>(_elements.PauseScreen
                    , uiRoot);
            _gameOverScreen = _container
                .InstantiatePrefabForComponent<GameOverScreen>(_elements.GameOverScreen
                , uiRoot);
            _tittleScreen = _container
                .InstantiatePrefabForComponent<TittleScreen>(_elements.TittleScreen
                , uiRoot);
            _pauseButton = _container
                .InstantiatePrefabForComponent<PauseButton>(_elements.PauseButton
                , uiRoot);
            _distancePresenter = _container
                .InstantiatePrefabForComponent<DistancePresenter>(_elements.DistancePresenter
                ,uiRoot);
        }

        public PauseScreen GetPauseScreen()
            => _pauseScreen;

        public TittleScreen GetTittleScreen()
            => _tittleScreen;

        public PauseButton GetPauseButton()
            => _pauseButton;

        public GameOverScreen GetGameOverScreen()
            => _gameOverScreen;

        public DistancePresenter GetDistancePresenter()
            => _distancePresenter;

    }
}