using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public delegate void ScoreConfirmedDelegate(int score);

    public Action<int> UnconfirmScoreChanged;
    public event ScoreConfirmedDelegate ScoreConfirmed;

    public int Score { get; private set; }
    [SerializeField] private GameActor _target;

    private Vector2 _startPosition = Vector2.zero;

    private int _unconfirmScore;

    private bool _scoreCounting;
    private void Awake()
    {
        _startPosition = _target.transform.position;
    }
    private void OnEnable()
    {
        _target.Jump += OnJump;
        _target.Land += OnLand;
    }

    private void OnDisable()
    {
        _target.Jump -= OnJump;
        _target.Land -= OnLand;
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
        _unconfirmScore = Mathf.RoundToInt(_target.transform.position.x - _startPosition.x);
        UnconfirmScoreChanged?.Invoke(_unconfirmScore);
    }
}
