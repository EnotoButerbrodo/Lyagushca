using UnityEngine;

namespace Lyaguska.Services
{
    public interface ILevelGenerationService : IResetable
    {
        void SpawnStartChunks(Vector2 startPosition);
        void CheckChunksRelevance();
    }
}