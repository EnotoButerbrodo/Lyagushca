namespace Lyaguska.Bootstrap
{
    public interface IGame 
    {
        void StartNewGame();
        void Reset();
        
        void Pause();
        void Resume();
        bool IsPaused { get; }
    }
}