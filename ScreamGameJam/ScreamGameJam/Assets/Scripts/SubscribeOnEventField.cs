using Ruinum.DynamicEvents.Scripts.Structs;
using UnityEngine;
using UnityEngine.Events;


public class SubscribeOnEventField : MonoBehaviour
{
    public UnityEvent OnEvent;
    public EventField EventField;

    private void Start()
    {
        EventField.Initialize();
        EventField.SubscribeOnEvent(() => OnEvent?.Invoke());
    }
}