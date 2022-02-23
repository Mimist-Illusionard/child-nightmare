using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayAudioEventLogic : EventLogic
{
    public AudioSource Audio => GetComponent<AudioSource>();

    public override void Logic()
    {
        Audio.Play();
    }
}
