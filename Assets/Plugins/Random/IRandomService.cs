namespace EnotoButebrodo
{
    public interface IRandomService
    {
        void SetSeed(int seed);
        float Range(float from, float to);
        int Range(int from, int to);
    }
}