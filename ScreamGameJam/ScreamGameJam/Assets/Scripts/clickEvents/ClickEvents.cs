using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour
{
    public List<KeyCode> keys = new List<KeyCode>();
    public float MinTimeToClick; // in sec
    public float MaxTimeToClick;

    public float ScoreToClick;
    public float ScoreToMiss;

    private float WinBar = 30f;

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
    }

    private void NewButton(float ScoreChange = 0)
    {
        WinBar += ScoreChange;
        if(WinBar < 100)
        {
            KeyCode CurrentKey = keys[Random.Range(0, keys.Count)];
            GameObject Button = Instantiate(prefab, canvas.transform);
            button = Button;
            Button.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-X, X), Random.Range(-Y, Y), 0);
            Button.transform.GetChild(0).GetComponent<TextMesh>().text = CurrentKey.ToString();
            StartCoroutine(ButtonTime(CurrentKey, Random.Range(MinTimeToClick, MaxTimeToClick)));
        }
        if(WinBar >= 100)
        {
            //Code
        }
    }

    private IEnumerator ButtonTime(KeyCode CurrentKey = 0, float TimeToClick = 0)
    {
        Image Circle = button.GetComponent<Image>();
        for (int i = 0; i < TimeToClick * 100; i++) // 1 sec
        {
            yield return new WaitForSeconds(0.01f);
            Circle.fillAmount -= (TimeToClick / 100f);
            if (Input.GetKeyDown(CurrentKey))
            {
                Destroy(button);
                NewButton(ScoreToClick);
                StopCoroutine(ButtonTime());
            }
        }
        NewButton(-ScoreToMiss);
    }
}
