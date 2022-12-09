namespace Lyaguska.LevelGeneration
{
    internal interface IChunkGenerator
    {
        Chunk GetChunk(float distance);
    }
}