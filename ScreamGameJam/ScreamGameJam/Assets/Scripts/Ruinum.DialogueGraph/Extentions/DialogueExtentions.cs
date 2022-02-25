using UnityEngine.UI;
using UnityEngine;

using TMPro;

using System.Collections;
using System;


public static class DialogueExtentions
{
    public static void DOFade(this TMP_Text TMP, float value, float speed, Action onEndAction = null)
    {
        CoroutineManager.Singleton.RunCoroutine(DOFadeTMPCoroutine(TMP, value, speed, onEndAction));
    }

    public static void DOFade(this Image image, float value, float speed, Action onEndAction = null)
    {
        CoroutineManager.Singleton.RunCoroutine(DOFadeImageCoroutine(image, value, speed, onEndAction));
    }

    public static void DOFade(this CanvasGroup canvasGroup, float value, float speed, Action onEndAction = null)
    {
        CoroutineManager.Singleton.RunCoroutine(DOFadeCanvasGroupCoroutine(canvasGroup, value, speed, onEndAction));
    }

    private static IEnumerator DOFadeTMPCoroutine(TMP_Text TMP, float value, float speed, Action onEndAction = null)
    {
        if (TMP.alpha >= value)
        {
            while (true)
            {
                TMP.alpha -= Time.deltaTime * speed;
                if (TMP.alpha <= value) { TMP.alpha = value; break; }
                yield return new WaitForEndOfFrame();
            }

        }
        else
            while (true)
            {
                TMP.alpha += Time.deltaTime * speed;
                if (TMP.alpha >= value) { TMP.alpha = value; break; }
                yield return new WaitForEndOfFrame();
            }

        onEndAction?.Invoke();
    }
    private static IEnumerator DOFadeImageCoroutine(Image image, float value, float speed, Action onEndAction = null)
    {
        float alpha = image.color.a;
        if (image.color.a >= value)
        {
            while (true)
            {
                alpha -= Time.deltaTime * speed;

                var color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                image.color = color;

                if (image.color.a <= value) { break; }
                yield return new WaitForEndOfFrame();
            }

        }
        else
            while (true)
            {
                alpha += Time.deltaTime * speed;

                var color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                image.color = color;

                if (image.color.a >= value) { break; }
                yield return new WaitForEndOfFrame();
            }

        onEndAction?.Invoke();
    }
    private static IEnumerator DOFadeCanvasGroupCoroutine(CanvasGroup canvasGroup, float value, float speed, Action onEndAction = null)
    {
        if (canvasGroup.alpha >= value)
        {
            while (true)
            {
                canvasGroup.alpha -= Time.deltaTime * speed;
                if (canvasGroup.alpha <= value) { canvasGroup.alpha = value; break; }
                yield return new WaitForEndOfFrame();
            }

        }
        else
            while (true)
            {
                canvasGroup.alpha += Time.deltaTime * speed;
                if (canvasGroup.alpha >= value) { canvasGroup.alpha = value; break; }
                yield return new WaitForEndOfFrame();
            }

        onEndAction?.Invoke();
    }
}
