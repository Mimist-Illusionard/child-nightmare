using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Data;


public class EventDatabaseHolder : MonoBehaviour
{
    [HideInInspector] public EventDatabase EventDatabase;

    public static EventDatabaseHolder Singleton { get; private set; }
    protected virtual void Awake() 
    {
        Singleton = this;
        EventDatabase = Resources.FindObjectsOfTypeAll<EventDatabase>()[0];

        if (EventDatabase == null) Debug.LogError($"Can't find {EventDatabase}. Please create one in Resource folder");
    }  
}