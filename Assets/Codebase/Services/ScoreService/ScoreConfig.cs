using UnityEngine;

namespace Codebase.Services.ScoreService
{
    [CreateAssetMenu(fileName = "ScoreConfig", menuName = "Config/Score", order = 0)]
    public class ScoreConfig : ScriptableObject
    {
        [field: SerializeField] public float MinDistanceForScore { get; private set; }
    }
}