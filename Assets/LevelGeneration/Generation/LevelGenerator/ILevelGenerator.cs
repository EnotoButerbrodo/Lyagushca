namespace Lyaguska.LevelGeneration
{
    public interface ILevelGenerator
    {
        void SpawnStart();
        void PlaceNewChunk(float distance);
    }
}