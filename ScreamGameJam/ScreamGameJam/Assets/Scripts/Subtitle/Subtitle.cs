using System.Collections;

using TMPro;
using DG.Tweening;

using UnityEngine;


public class Subtitle : BaseSingleton<Subtitle>
{
    public TMP_Text Text;
    public float FadeDuration;
    public float WaitTime;

    public void PlaySubtitle()
    {
        //Set text value
        Text.DOFade(1f, FadeDuration).OnComplete(() => StartCoroutine(FadeOut()));
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(WaitTime);
        Text.DOFade(0f, FadeDuration);
    }
}
