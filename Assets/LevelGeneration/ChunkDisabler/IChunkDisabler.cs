namespace Lyaguska.LevelGeneration
{
    public interface IChunkDisabler
    {
        public event System.Action<Chunk> DisableRequest;
    }
}