using System;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts.Structs
{
    [Serializable]
    public struct EventField
    {
        public EventEntry EventEntry;
        private EventEntry _eventEntry;

        public void Initialize()
        {
            if (!EventDatabaseHolder.Singleton.EventDatabase.TryFindEvent(EventEntry.ID, out _eventEntry)) Debug.LogError($"Can't find {EventEntry.Name} of {typeof(EventEntry)}");
        }

        public void SubscribeOnEvent(Action action = null)
        {
            if (_eventEntry == null) return;
            _eventEntry.OnEventTriggered += action;
        }

        public void TriggerEvent()
        {
            if (_eventEntry == null) return;
            if (!_eventEntry.CheckEntires()) return;

            _eventEntry.Execute();
            _eventEntry.OnEventTriggered?.Invoke();
        }
    }
}