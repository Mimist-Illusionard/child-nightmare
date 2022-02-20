using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Data;


public class EventDatabaseHolder : MonoBehaviour
{
    public EventDatabase EventDatabase;

    public static EventDatabaseHolder Singleton { get; private set; }
    protected virtual void Awake() 
    {
        Singleton = this;

        if (EventDatabase == null) { Debug.LogError($"Please set {typeof(EventDatabase)} in field"); return; }
    }  
}