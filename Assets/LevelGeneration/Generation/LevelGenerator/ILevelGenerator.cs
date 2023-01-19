namespace Lyaguska.LevelGeneration
{
    public interface ILevelGenerator
    {
        void SpawnStartChunk();
        void PlaceNewChunk(float distance);
    }
}