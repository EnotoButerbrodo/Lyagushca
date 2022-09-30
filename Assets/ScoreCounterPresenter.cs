using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounterPresenter : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private TextMeshProUGUI _confirmedScoreText;
    [SerializeField] private TextMeshProUGUI _unconfirmedScoreText;
    [SerializeField][Range(0, 1f)] private float _scoreAddDelay;

    private void ScoreConfirmed(int score)
    {
        _confirmedScoreText.text = score.ToString();
        _unconfirmedScoreText.text = null;
    }

   
    private void UnconfirmedScoreChanged(int score)
    {
        if(score == 0) 
        {
            return;
        }
        _unconfirmedScoreText.text = "+ " + score.ToString();
    }

    private void OnEnable()
    {
        _counter.ScoreConfirmed += ScoreConfirmed;
        _counter.UnconfirmScoreChanged += UnconfirmedScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreConfirmed -= ScoreConfirmed;
        _counter.UnconfirmScoreChanged -= UnconfirmedScoreChanged;
    }
}
