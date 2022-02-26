using System.Collections.Generic;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts.Data
{
    [CreateAssetMenu(fileName = "EventDatabase", menuName = "Ruinum/DynamicEvents/EventDatabase")]
    public class EventDatabase : ScriptableObject
    {
        public List<EventTable> EventTables;
        public List<RuleEntry> RuleEntries;

        public void AddActiveRule(RuleEntry ruleEntry)
        {
            RuleEntries.Add(ruleEntry);
        }

        public void RemoveActiveRule(RuleEntry rule)
        {
            RuleEntries.Remove(rule);
        }

        #region TryFind Methods
        public bool TryFindEvent(string id, out EventEntry eventEntry)
        {
            eventEntry = default;
            for (int i = 0; i < EventTables.Count; i++)
            {
                for (int j = 0; j < EventTables[i].Events.Count; j++)
                {
                    if (EventTables[i].Events[j].ID == id)
                    {
                        eventEntry = EventTables[i].Events[j];
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TryFindFact(string id, out FactEntry factEntry)
        {
            factEntry = default;
            for (int i = 0; i < EventTables.Count; i++)
            {
                for (int j = 0; j < EventTables[i].Facts.Count; j++)
                {
                    if (EventTables[i].Facts[j].ID == id)
                    {
                        factEntry = EventTables[i].Facts[j];
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TryFindRule(string id, out RuleEntry ruleEntry)
        {
            ruleEntry = default;
            for (int i = 0; i < EventTables.Count; i++)
            {
                for (int j = 0; j < EventTables[i].Rules.Count; j++)
                {
                    if (EventTables[i].Rules[j].ID == id)
                    {
                        ruleEntry = EventTables[i].Rules[j];
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion
    }
}