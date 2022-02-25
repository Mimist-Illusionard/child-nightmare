using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

public class ClickEvents : MonoBehaviour
{
    public UnityEvent EndEventesWin = new UnityEvent();
    public UnityEvent EndEventesLose = new UnityEvent();

    public UnityEvent ClickEffect = new UnityEvent();
    public UnityEvent MissEffect = new UnityEvent();

    public List<KeyCode> keys = new List<KeyCode>();
    public float MinTimeToClick; // in sec
    public float MaxTimeToClick;

    public float ScoreToClick;
    public float ScoreToMiss;

    private float WinBar = 30f;
    public Image Bar;

    public int X;
    public int Y;

    public GameObject prefab;
    private GameObject canvas;
    private GameObject button;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().gameObject;
    }

    public void StartEvents()
    {
        NewButton();
        Bar.gameObject.SetActive(true);
    }

    private void Win()
    {
        EndEventesWin.Invoke();
    }

    private void Lose()
    {
        EndEventesLose.Invoke();
    }

    private void NewButton(float ScoreChange = 0)
    {
        WinBar += ScoreChange;
        Bar.fillAmount = WinBar / 100;
        if(WinBar < 100)
        {
            KeyCode CurrentKey = keys[Random.Range(0, keys.Count)];
            GameObject Button = Instantiate(prefab, canvas.transform);
            button = Button;
            Button.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-X, X), Random.Range(-Y, Y), 0);
            Button.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = CurrentKey.ToString();
            StartCoroutine(ButtonTime(CurrentKey, Random.Range(MinTimeToClick, MaxTimeToClick)));
        }
        if(WinBar <= 0)
        {
            Bar.gameObject.SetActive(false);
            Lose();
        }
        if(WinBar >= 100)
        {
            Win();
            Bar.gameObject.SetActive(false);
        }
    }

    private IEnumerator ButtonTime(KeyCode CurrentKey = 0, float TimeToClick = 0)
    {
        Debug.Log(CurrentKey.ToString());
        Image Circle = button.GetComponent<Image>();
        Circle.gameObject.transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 1, 2);
        Circle.DOFillAmount(0, TimeToClick);
        for (int i = 0; i < TimeToClick * 100; i++) // 1 sec
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(CurrentKey))
            {
                Destroy(button);
                ClickEffect.Invoke();
                StopAllCoroutines();
                NewButton(ScoreToClick);
            }
        }
        Destroy(button);
        MissEffect.Invoke();
        NewButton(-ScoreToMiss);
    }
}
