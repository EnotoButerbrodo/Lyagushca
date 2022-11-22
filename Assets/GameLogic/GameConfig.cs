using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Config")]
public class GameConfig : ScriptableObject
{
    [Header("JumpCharger")]
    [SerializeField] private float _jumpCharge_MinRadius;
    [SerializeField] private float _jumpCharge_MaxRadius;

    public float JumpCharge_MinRadius => _jumpCharge_MinRadius;
    public float JumpCharge_MaxRadius => _jumpCharge_MaxRadius;

    [Header("AutoCharge")]
    [SerializeField][Range(0, 10f)] private float _autoCharge_MaxChargeTimeInSeconds = 1f;
    [SerializeField][Range(0, 100)] private int _autoCharge_TicksCount = 20;

    public float AutoCharge_MaxChargeTimeInSeconds => _autoCharge_MaxChargeTimeInSeconds;
    public int AutoCharge_TickCount => _autoCharge_TicksCount;


    [Header("Jumps")]
    [SerializeField][Range(0, 1f)] private float _delayJumpTime;
    [SerializeField][Range(0, 1f)] private float _jumpsDelay;

    public float DelayJumpTime => _delayJumpTime;
    public float JumpsDelay  => _jumpsDelay;

}
