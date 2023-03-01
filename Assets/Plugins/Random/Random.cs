using Random = UnityEngine.Random;

namespace EnotoButebrodo
{
    public static class Random
    {
        private static float _lastNumber;

        public static void SetSeed(int seed)
        {
            UnityEngine.Random.InitState(seed);
        }

        public static float Range(float from, float to)
        {
            float number = UnityEngine.Random.Range(from, to);

            return ResolveRepitition(number, from, to);
        }

        public static int Range(int from, int to)
        {
            int number = UnityEngine.Random.Range(from, to + 1);

            return (int)ResolveRepitition(number, from, to);
        }

        private static float ResolveRepitition(float number, float from, float to)
        {
            if (number == _lastNumber)
            {
                float fromResolve = (number - from) * -1;
                float toResolve = to - number;
                number += UnityEngine.Random.Range(fromResolve, toResolve);
            }

            _lastNumber = number;
            return number;
        }

        
    }
}