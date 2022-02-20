using System.Collections.Generic;
using System;


namespace Ruinum.DynamicEvents.Scripts.Entries
{
    [Serializable]
    public class RuleEntry : LogicalEntry
    {
        public EventEntry TriggeredBy;
        public List<EventEntry> Triggers = new List<EventEntry>();

        public RuleEntry(string name, string Id) : base(name, Id)
        {
        }

        public override void Execute()
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (!Triggers[i].CheckEntires()) continue;
            }

            base.Execute();
        }
    }
}
