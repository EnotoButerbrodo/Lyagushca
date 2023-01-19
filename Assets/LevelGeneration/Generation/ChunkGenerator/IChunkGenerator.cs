namespace Lyaguska.LevelGeneration
{
    internal interface IChunkGenerator
    {
        Chunk GetStartChunk();
        Chunk GetChunk(float distance);
    }
}