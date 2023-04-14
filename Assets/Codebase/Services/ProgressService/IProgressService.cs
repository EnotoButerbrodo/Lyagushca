namespace Lyaguska.Services
{
    public interface IProgressService
    {
        int GetHighScore();
        void UpdateHighScore(int score);
    }
}