using UnityEngine.Events;


public class TimerDelayEventLogic : EventLogic
{
    public float Time;
    public UnityEvent OnTimerEnd;

    public override void Logic()
    {
        TimerManager.Singleton.StartTimer(Time, () => OnTimerEnd?.Invoke());
    }
}
