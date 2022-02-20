using System;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Structs;


namespace Ruinum.DynamicEvents.Scripts
{
    public class EventField_DE : MonoBehaviour
    {
        public EventField EventField;

        public void Awake()
        {
            EventField.Initialize();
        }

        public void StartEvent()
        {
            EventField.TriggerEvent();
        }

        public void SubscribeOnEvent(Action action = null)
        {
            EventField.SubscribeOnEvent(action);
        }
    }
}