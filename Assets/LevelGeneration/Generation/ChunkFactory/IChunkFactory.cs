using System.Collections.Generic;

namespace Lyaguska.LevelGeneration
{
    public interface IChunkFactory
    {
        Chunk GetChunk(ChunkType type, float distance);
    }
}