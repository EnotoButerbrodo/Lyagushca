using UnityEngine;

namespace Lyaguska.Services
{
    public interface ILevelGenerationService
    {
        void SpawnStartChunks(Vector2 startPosition);
        void CheckChunksRelevance();
    }
}