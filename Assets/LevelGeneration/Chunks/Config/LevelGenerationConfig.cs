using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
    [CreateAssetMenu(menuName = "Config/LevelGeneration/LevelGenerationConfig")]
    public class LevelGenerationConfig : ScriptableObject
    {
        [Header("Сид")]
        [SerializeField] private int _seed;
        [SerializeField] private bool _useRandomSeed;

        public int Seed => _seed;
        public bool UseRandomSeed => _useRandomSeed;

        [Header("Параметры расстановки")]

        [Header("Отступы Y")]
        [SerializeField] private float _minYOffset;
        [SerializeField] private float _maxYOffset;

        [Space]
        [Header("Отступы X")]
        [SerializeField] private float _minXOffset;
        [SerializeField] private float _maxXOffset;

        [Space]
        [Header("Ограничение позиции Y")]
        [SerializeField] private float _minChunkY;
        [SerializeField] private float _maxChunkY;

        public float MinYOffset => _minYOffset;
        public float MaxYOffset => _maxYOffset;

        public float MinXOffset => _minXOffset;
        public float MaxXOffset => _maxXOffset;

        public float MinChunkY => _minChunkY;
        public float MaxChunkY => _maxChunkY;


    }
}