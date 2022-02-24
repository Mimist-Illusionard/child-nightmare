using UnityEngine;

using DG.Tweening;


public class BlackScreen : MonoBehaviour
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