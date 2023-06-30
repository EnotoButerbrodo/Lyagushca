namespace Lyaguska.Services
{
    public class InterfaceService : IInterfaceService
    {
        private readonly IUIFactory _uiFactory;

        public InterfaceService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void ShowUI()
        {
            _uiFactory.GetPauseButton().gameObject.SetActive(true);
        }

        public void HideUI()
        {
            _uiFactory.GetPauseButton().gameObject.SetActive(false);
            _uiFactory.GetScorePresenter().Hide();
        }
        public void ShowPauseScreen() 
            => _uiFactory.GetPauseScreen().Show();

        public void ShowGameOverScreen(int distance, int highScore) 
            => _uiFactory.GetGameOverScreen().Show(distance);

        public void ShowTittleScreen()
            => _uiFactory.GetTittleScreen().Show();
    }
}