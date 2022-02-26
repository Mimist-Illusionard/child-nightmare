using UnityEngine;


public class BlackScreen : MonoBehaviour
{
    public CanvasGroup Screen;
    public float FadeDuration;
    public bool isFading;

    public void FadeIn()
    {
        if (isFading) return;

        isFading = true;
        Screen.DOFade(1f, FadeDuration, () => { isFading = false; });
    }   
    
    public void FadeOut()
    {
        if (isFading) return;

        isFading = true;
        Screen.DOFade(0f, FadeDuration, () => { isFading = false; });
    }
}