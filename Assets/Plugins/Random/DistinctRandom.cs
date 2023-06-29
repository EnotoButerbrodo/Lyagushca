using System.Collections.Generic;
using UnityEngine;

namespace EnotoButebrodo
{
    public class DistinctRandom : IDistinctRandom
    {
        private List<int> _numbers;

        private int _from;
        private int _to;

        private int numbersCount
            => _to - _from;

        public DistinctRandom(int from, int to)
        {
            _from = from;
            _to = to;
            
            _numbers = new List<int>(numbersCount);

        }

        private void GenerateDistinctNumbers()
        {
            for (int i = _from; i < _to; i++)
            {
                _numbers.Add(i);
            }
        }
        public int GetDistinctNumber()
        {
            if (_numbers.Count == 0)
                GenerateDistinctNumbers();

            var index = UnityEngine.Random.Range(0, _numbers.Count); 
            Debug.Log($"{index} / {_numbers.Count - 1}");
            var distinctRandomValue = _numbers[index];
            _numbers.RemoveAt(index);

            return distinctRandomValue;
        }


    }
}