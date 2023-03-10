namespace Lyaguska.Bootstrap
{
    public interface IGame 
    {
        void StartGame();
        void ResetGame();
        
        void Pause();
        void Resume();
        bool IsPaused { get; }
    }
}