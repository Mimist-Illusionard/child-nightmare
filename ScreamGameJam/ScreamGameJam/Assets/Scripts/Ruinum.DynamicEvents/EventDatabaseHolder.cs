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

    private void Update()
    {
        for (int i = 0; i < EventDatabase.RuleEntries.Count; i++)
        {
            if (!EventDatabase.RuleEntries[i].CheckEntires()) continue;
            EventDatabase.RuleEntries[i].Execute();
        }
    }
}