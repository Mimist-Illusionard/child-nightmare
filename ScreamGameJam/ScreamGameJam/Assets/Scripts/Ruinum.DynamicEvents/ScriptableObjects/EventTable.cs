﻿using Ruinum.DynamicEvents.Scripts.Entries;
using System.Collections.Generic;
using UnityEngine;



namespace Ruinum.DynamicEvents.Scripts.Data
{
    [CreateAssetMenu(fileName = "EventTable", menuName = "Ruinum/DynamicEvents/EventTable")]
    public class EventTable : ScriptableObject
    {
        public List<FactEntry> Facts = new List<FactEntry>();
        public List<EventEntry> Events = new List<EventEntry>();
        public List<RuleEntry> Rules = new List<RuleEntry>();
    }
}
