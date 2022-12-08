namespace Lyaguska.LevelGeneration
{
    public interface IChunkGenerator
    {
        Chunk GetChunk(int score);
    }
}