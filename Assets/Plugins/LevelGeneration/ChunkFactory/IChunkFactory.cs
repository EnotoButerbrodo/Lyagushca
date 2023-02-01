namespace EnotoButerbrodo.LevelGeneration
{
    public interface IChunkFactory
    {
        Chunk GetChunk(ChunkType type, float distance = 0);
    }
}