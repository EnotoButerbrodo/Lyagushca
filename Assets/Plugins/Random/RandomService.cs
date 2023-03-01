using Random = UnityEngine.Random;

namespace EnotoButebrodo
{
    public class RandomService : IRandomService
    {
        private float _lastNumber;

        private const float RepititionDifferenceKoeff = .05f;

        public void SetSeed(int seed)
        {
            Random.InitState(seed);
        }

        public float Range(float from, float to)
        {
            float number = Random.Range(from, to);

            return ResolveRepitition(number, from, to);
        }

        public int Range(int from, int to)
        {
            int number = Random.Range(from, to + 1);

            return (int)ResolveRepitition(number, from, to);
        }

        private float ResolveRepitition(float number, float from, float to)
        {
            if (number == _lastNumber)
            {
                float fromResolve = (number - from) * -1;
                float toResolve = to - number;
                number += Random.Range(fromResolve, toResolve);
            }

            _lastNumber = number;
            return number;
        }

        
    }
}