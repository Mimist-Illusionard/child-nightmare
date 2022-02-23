using UnityEngine;
using TMPro;
using System.Collections;


//Yeah yeah. This script is very awful but now i don't write some new thing like dialogue graph or dynamic events
public class MirrorWritingEventLogic : EventLogic
{
    public AudioSource Audio;
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public TMP_Text Text4;

    public float WaitTime;
    public float FadeInSpeed;
    public float FadeOutSpeed;

    public override void Logic()
    {
        StartCoroutine(StartWriting());
    }

    private IEnumerator StartWriting()
    {
        PlayAudio();
        StartCoroutine(FadeIn(Text1));
        yield return new WaitForSeconds(WaitTime);
        PlayAudio();
        StartCoroutine(FadeIn(Text2));
        yield return new WaitForSeconds(WaitTime + Random.Range(-1.5f, 0f));
        StartCoroutine(FadeOut(Text1));
        StartCoroutine(FadeOut(Text2));
        yield return new WaitForSeconds(3f);
        PlayAudio();
        Audio.pitch = 0.45f;
        StartCoroutine(FadeIn(Text3));
        yield return new WaitForSeconds(2f);
        PlayAudio();
        Audio.pitch = 0.4f;
        StartCoroutine(FadeIn(Text4));
    }

    private IEnumerator FadeOut(TMP_Text text)
    {
        float alpha = text.color.a;
        while (true) 
        {
            alpha -= Time.deltaTime * FadeOutSpeed;
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return new WaitForEndOfFrame();
            if (alpha <= 0) break;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
    }

    private IEnumerator FadeIn(TMP_Text text)
    {
        float alpha = 0;
        while (true)
        {
            alpha += Time.deltaTime * FadeInSpeed;
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return new WaitForEndOfFrame();
            if (alpha >= 1) break;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
    }

    private void PlayAudio()
    {
        Audio.pitch = Random.Range(0.5f, 0.7f);
        Audio.Play();
    }
}