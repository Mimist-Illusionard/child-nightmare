using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioMixerGroup Master;
    public AudioMixerGroup Amdient;
    public AudioMixerGroup EventSounds;

    public float Sens = 1f;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MasterMixer(Slider slider)
    {
        Master.audioMixer.SetFloat("Master", slider.value);
    }

    public void AmdientSound(Slider slider)
    {
        Amdient.audioMixer.SetFloat("Ambient", slider.value);
    }

    public void EventsSounds(Slider slider)
    {
        EventSounds.audioMixer.SetFloat("Enents", slider.value);
    }

    public void MouseSens(Slider slider)
    {
        Sens = slider.value;
    }
}
