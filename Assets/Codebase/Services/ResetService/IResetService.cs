namespace Lyaguska.Services
{
    public interface IResetService : IResetable
    {
        void Register(IResetable resetable);
    }
}