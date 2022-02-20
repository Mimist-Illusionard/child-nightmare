using System;
using System.Collections.Generic;

using UnityEngine;


public class Timer : IExecute
{
    private List<Timer> _timers;
    public float CurrentTime;
    public Action OnTimerEnd;

    public Timer(List<Timer> timers = null, float time = 1f, Action onTimerEnd = null)
    {
        _timers = timers;
        CurrentTime = time;
        OnTimerEnd = onTimerEnd;
    }

    public void Execute()
    {
        CurrentTime -= Time.deltaTime;

        if (CurrentTime <= 0f) { OnTimerEnd?.Invoke(); _timers.Remove(this); }
    }

    public void RemoveTimer()
    {
        _timers.Remove(this);
    }
}