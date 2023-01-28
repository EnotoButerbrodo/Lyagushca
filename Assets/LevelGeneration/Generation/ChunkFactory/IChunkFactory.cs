using System.Collections.Generic;

namespace Lyaguska.LevelGeneration
{
    public interface IChunkFactory
    {
        Chunk GetStartChunk();
        Chunk GetChunk(float distance);
    }
}