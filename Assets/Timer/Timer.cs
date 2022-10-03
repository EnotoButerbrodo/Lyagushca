using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool _reversed;
    public event Action<TimerEventArgs> Started;
    public event Action<TimerEventArgs> Tick;
    public event Action Finished;
    private bool _stopRequsted;

    private Func<float, IEnumerator> _timerHandler;

    private void Awake()
    {
        _timerHandler = _reversed ? ReverseTimerHandler : TimerHandler;
    }
    public bool IsStarted { get; private set; }
    public void StartTimer(float time)
    {
        IsStarted = true;
        StartCoroutine(_timerHandler(time));

    }

    public void Stop()
    {
        _stopRequsted = true;
        Finished?.Invoke();
    }


    private IEnumerator TimerHandler(float time)
    {
        _stopRequsted = false;
        Started?.Invoke(new TimerEventArgs(0, time));

        for (float currentTime = 0; currentTime < time; currentTime += Time.deltaTime)
        {
            if (_stopRequsted)
            {
                _stopRequsted = false;
                break;
            }
            Tick?.Invoke(new TimerEventArgs(currentTime, time));
            yield return null;
        }

        IsStarted = false;
        Finished?.Invoke();
    }

    private IEnumerator ReverseTimerHandler(float time)
    {
        Started?.Invoke(new TimerEventArgs(0, time));

        for (float currentTime = time; currentTime > 0; currentTime -= Time.deltaTime)
        {
            if (_stopRequsted)
            {
                _stopRequsted = false;
                break;
            }

            Tick?.Invoke(new TimerEventArgs(currentTime, time));
            yield return null;
        }

        IsStarted = false;
        Finished?.Invoke();
    }
}

public class TimerEventArgs
{
    public float CurrentTime { get; private set; }
    public float MaxTime { get; private set; }

    public TimerEventArgs(float currentTime, float maxTime)
    {
        CurrentTime = currentTime;
        MaxTime = maxTime;
    }
}


