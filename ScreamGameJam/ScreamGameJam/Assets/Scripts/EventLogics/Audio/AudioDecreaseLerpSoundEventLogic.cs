using System.Collections;
using UnityEngine;


public class AudioDecreaseLerpSoundEventLogic : EventLogic
{
    public AudioSource Audio;
    public float Volume;
    public float Speed;

    public override void Logic()
    {
        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator DecreaseVolume()
    {
        float volume = Audio.volume;
        while (true)
        {
            volume -= Time.deltaTime * Speed;

            yield return new WaitForEndOfFrame();
            if (volume <= Volume) break;
        }

        Audio.volume = Volume;
    }
}