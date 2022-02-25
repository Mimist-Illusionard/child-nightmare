using UnityEngine;


public class StopAudioEventLogic : EventLogic
{
    public AudioSource Audio;

    public override void Logic()
    {
        Audio.Stop(); 
    }
}
