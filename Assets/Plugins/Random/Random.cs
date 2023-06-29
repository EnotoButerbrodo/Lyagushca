using UnityEngine;
using Random = UnityEngine.Random;

namespace EnotoButebrodo
{
    public static class Random
    {
        public static int DistinctResolveIterationCount = 1;
        private static float _lastNumber;

        public static void SetSeed(int seed)
        {
            UnityEngine.Random.InitState(seed);
        }

        public static float Range(float from, float to)
        {
            float number = UnityEngine.Random.Range(from, to);

            return ResolveRepeat(number, from, to);
        }

        public static int Range(int from, int to)
        {
            int number = UnityEngine.Random.Range(from, to + 1);

            return (int)ResolveRepeat(number, from, to);
        }

        private static float ResolveRepeat(float number, float from, float to)
        {
            if (number == _lastNumber)
            {
                for (int i = 0; i < DistinctResolveIterationCount; i++)
                {
                    number = UnityEngine.Random.Range(from, to);
                    
                    if(number != _lastNumber)
                        break;
                }
            }
            
            _lastNumber = number;
            return number;
        }

        
    }
}