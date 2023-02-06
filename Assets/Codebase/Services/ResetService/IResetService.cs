namespace Lyaguska.Services
{
    public interface IResetService : IResetable
    {
        void Register(IResetable resetable);
        void Unregister(IResetable resetable);
    }
}