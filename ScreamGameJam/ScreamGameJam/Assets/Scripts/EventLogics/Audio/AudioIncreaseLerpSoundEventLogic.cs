using System.Collections;
using UnityEngine;


public class AudioIncreaseLerpSoundEventLogic : EventLogic
{
    public AudioSource Audio; 
    public float Volume;
    public float Speed;

    public override void Logic()
    {
        StartCoroutine(IncreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        float volume = Audio.volume;
        while (true)
        {
            volume += Time.deltaTime * Speed;
            
            yield return new WaitForEndOfFrame();
            if (volume >= Volume) break;
        }

        Audio.volume = Volume;
    }
}