using EnotoButerbrodo.LevelGeneration.Chunks;

namespace EnotoButerbrodo.LevelGeneration.Factory
{
    public interface IChunkFactory
    {
        Chunk GetChunk(ChunkType type, float distance = 0);
    }
}