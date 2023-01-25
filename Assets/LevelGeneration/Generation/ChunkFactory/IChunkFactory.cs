namespace Lyaguska.LevelGeneration
{
    internal interface IChunkFactory
    {
        Chunk GetStartChunk();
        Chunk GetChunk(float distance);
    }
}