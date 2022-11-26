using Lyaguska.Core;
using System;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour, IResetable
{
    public delegate void ScoreConfirmedDelegate(int score);

    public Action<int> UnconfirmScoreChanged;
    public event ScoreConfirmedDelegate ScoreConfirmed;

    public int Score { get; private set; }

    [Inject] private GameActor _target;

    private Vector2 _startPosition = Vector2.zero;

    private int _unconfirmScore;

    private bool _scoreCounting;

    public void Reset()
    {
        _scoreCounting = false;
        _startPosition = _target.transform.position;
        Score = 0;
        _unconfirmScore = 0;
        ScoreConfirmed?.Invoke(0);
    }

    private void Awake()
    {
        Reset();
    }

    private void OnEnable()
    {
        _target.Jumped += OnJump;
        _target.GroundLand += OnLand;
    }

    private void OnDisable()
    {
        _target.Jumped -= OnJump;
        _target.GroundLand -= OnLand;
    }

    private void OnJump()
    {
        _scoreCounting = true;
        _startPosition = _target.transform.position;
        _unconfirmScore = 0;
    }
    private void OnLand()
    {
        _scoreCounting = false;
        Score += _unconfirmScore;

        ScoreConfirmed?.Invoke(Score);
    }

    private void FixedUpdate()
    {
        if(_scoreCounting == false)
        {
            return;
        }
        _unconfirmScore = Mathf.RoundToInt(Mathf.Floor(_target.transform.position.x - _startPosition.x));
        UnconfirmScoreChanged?.Invoke(_unconfirmScore);
    }
}
