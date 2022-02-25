using System;


namespace Ruinum.DynamicEvents.Scripts.Entries
{
    [Serializable]
    public class EventEntry : LogicalEntry
    {
        public RuleEntry Rule = null;
        public Action OnEventTriggered;

        public EventEntry(string name, string Id) : base(name, Id)
        {
        }

        public override void Execute()
        {
            base.Execute();
            if (Rule.ID == null) return;

            if (EventDatabaseHolder.Singleton.EventDatabase.TryFindRule(Rule.ID, out var rule))
                EventDatabaseHolder.Singleton.EventDatabase.AddActiveRule(rule);
        }
    }
}