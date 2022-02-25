using System.Collections;
using UnityEngine;
using TMPro;

using Ruinum.DynamicEvents.Scripts.Structs;


public class TVEventLogic : EventLogic
{
    public TMP_Text[] Texts;
    public float WaitTime;
    public EventField Event;

    private int _currentPhrase = 0;
    public override void Logic()
    {
        Event.Initialize();
        StartCoroutine(WritePhrase());
    }

    public IEnumerator WritePhrase()
    {
        Texts[_currentPhrase].gameObject.SetActive(true);

        yield return new WaitForSeconds(WaitTime);
        Texts[_currentPhrase].gameObject.SetActive(false);

        _currentPhrase++;
        if (_currentPhrase < Texts.Length) StartCoroutine(WritePhrase());
        else Event.TriggerEvent();
    }
}
