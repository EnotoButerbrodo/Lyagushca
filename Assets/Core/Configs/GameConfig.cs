using UnityEngine;
using UnityEngine.UI;

namespace Lyaguska.Core.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Config")]

    public class GameConfig : ScriptableObject
    {
        [Header("AutoCharge")]
        [SerializeField][Range(0, 10f)] private float _autoCharge_MaxChargeTimeInSeconds = 1f;
        [SerializeField][Range(0, 100)] private int _autoCharge_TicksCount = 20;

        public float AutoCharge_MaxChargeTimeInSeconds => _autoCharge_MaxChargeTimeInSeconds;
        public int AutoCharge_TickCount => _autoCharge_TicksCount;


        [Header("Jumps")]
        [SerializeField][Range(0, 1f)] private float _delayJumpTime;
        [SerializeField][Range(0, 1f)] private float _kayoteJumpDelay;

        [Tooltip("Задержка перед \"кайот\" прыжком")]
        public float DelayJumpTime => _delayJumpTime;
        [Tooltip("Время кайота для прыжка")]
        public float KayoteJumpDelay => _kayoteJumpDelay;

    }
}