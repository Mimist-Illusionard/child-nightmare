using System;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts.Structs
{
    [Serializable]
    public struct FactField
    {
        public FactEntry FactEntry;
        private FactEntry _factEntry;

        public void Initialize()
        {
            if (!EventDatabaseHolder.Singleton.EventDatabase.TryFindFact(FactEntry.ID, out _factEntry)) Debug.LogError($"Can't find {FactEntry.Name} of {typeof(FactEntry)}");
        }        
    }
}
