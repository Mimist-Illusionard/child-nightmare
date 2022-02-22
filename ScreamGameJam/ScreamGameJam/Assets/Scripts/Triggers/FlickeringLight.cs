using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Light), typeof(AudioSource))]
public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private float _waitFlickerTime;
    [SerializeField] private float _flickTime;
    [SerializeField] private float _randomTime;
    [SerializeField] private AudioClip _audioClip;

    private Light _light => GetComponent<Light>();
    private AudioSource _audioSource => GetComponent<AudioSource>();

    public void Start()
    {
        StartWaitTime();
    }

    private IEnumerator Flick()
    {
        _light.enabled = false;
        PlayAudio();
        yield return new WaitForSeconds(_flickTime + Random.Range(0, _randomTime));
        _light.enabled = true;
        PlayAudio();
        yield return new WaitForSeconds(_flickTime + Random.Range(0, _randomTime));
        _light.enabled = false;
        PlayAudio();
        yield return new WaitForSeconds(_flickTime + Random.Range(0, _randomTime));
        _light.enabled = true;
        PlayAudio();
        yield return new WaitForSeconds(_flickTime + Random.Range(0, _randomTime));
        _light.enabled = false;
        PlayAudio();
        yield return new WaitForSeconds(_flickTime + Random.Range(0, _randomTime));
        _light.enabled = true;
        PlayAudio();

        StartWaitTime();
    }

    private void StartWaitTime()
    {
        TimerManager.Singleton.StartTimer(_waitFlickerTime + Random.Range(0, _randomTime), () => StartCoroutine(Flick()));
    }

    private void PlayAudio()
    {
        if (!_audioClip) return;
        _audioSource.pitch = Random.Range(0.7f, 1f);
        _audioSource.PlayOneShot(_audioClip);
    }
}
