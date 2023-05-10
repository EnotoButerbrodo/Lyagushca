namespace EnotoButebrodo
{
    public interface ITimersService
    {
        Timer GetTimer();
        void DeleteTimer(Timer timer);
    }
}