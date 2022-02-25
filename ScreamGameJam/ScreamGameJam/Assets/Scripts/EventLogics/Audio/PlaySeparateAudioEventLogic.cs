using UnityEngine;

public class PlaySeparateAudioEventLogic : EventLogic
{
    public AudioSource Audio;

    public override void Logic()
    {
        Audio.Play();
    }
}