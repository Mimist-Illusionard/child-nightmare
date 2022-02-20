using System;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts.Structs
{
    [Serializable]
    public struct RuleField
    {
        public RuleEntry RuleEntry;
        private RuleEntry _ruleEntry;

        public void Initialize()
        {
            if (!EventDatabaseHolder.Singleton.EventDatabase.TryFindRule(RuleEntry.ID, out _ruleEntry)) Debug.LogError($"Can't find {RuleEntry.Name} of {typeof(RuleEntry)}");
        }
    }
}
