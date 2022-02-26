using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;


public class Subtitle : MonoBehaviour
{
    public TMP_Text Text;
    public CanvasGroup Sprite;
    public float FadeSpeed;
    public float WaitTime;

    public Queue<string> Subtitles;

    private bool _isDrawingSubtitle;

    public static Subtitle Singleton { get; private set; }
    private void Awake() => Singleton = this;

    private void Start()
    {
        Subtitles = new Queue<string>();
    }

    public void AddSubtitleInQueue(string text)
    {
        Subtitles.Enqueue(text);
    }

    private void DrawSubtitle(string text)
    {
        _isDrawingSubtitle = true;

        Text.text = text;
        Sprite.DOFade(0.6f, FadeSpeed, () => { StartCoroutine(FadeOut());});
    }

    private void Update()
    {
        if (Subtitles.Count <= 0 || _isDrawingSubtitle) return;
        DrawSubtitle(Subtitles.Dequeue());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(WaitTime);
        Sprite.DOFade(0f, FadeSpeed, () => _isDrawingSubtitle = false);
    }
}