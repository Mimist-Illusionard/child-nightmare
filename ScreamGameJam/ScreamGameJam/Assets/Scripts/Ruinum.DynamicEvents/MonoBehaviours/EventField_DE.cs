using System;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Structs;


namespace Ruinum.DynamicEvents.Scripts
{
    public class EventField_DE : MonoBehaviour
    {
        [SerializeField] private EventField EventField;

        private void Start()
        {
            Debug.Log($"Initialzing {typeof(EventField)} in {this}");
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