namespace Lyaguska.Services
{
    public interface ILeaderboard
    {
        void SaveResult(string nickname, int score);
    }
}