using UnityEngine;

using DG.Tweening;


public class BlackScreen : BaseSingleton<BlackScreen>
{
    public CanvasGroup Screen;
    public float FadeDuration;

    public void FadeIn()
    {
        Screen.DOFade(1f, FadeDuration);
    }   
    
    public void FadeOut()
    {
        Screen.DOFade(0f, FadeDuration);
    }
}