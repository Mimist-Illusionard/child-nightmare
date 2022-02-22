using UnityEngine;


public class CraneEventLogic : EventLogic
{
    public AudioSource SqueakSound;
    public AudioSource RunningWaterSound;

    public override void Logic()
    {
        SqueakSound.Play();
        TimerManager.Singleton.StartTimer(SqueakSound.clip.length, () => RunningWaterSound.Play());
    }
}