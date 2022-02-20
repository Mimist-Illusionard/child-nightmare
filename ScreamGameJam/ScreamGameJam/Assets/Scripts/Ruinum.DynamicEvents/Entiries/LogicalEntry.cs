using System;
using System.Collections.Generic;
using UnityEngine;


namespace Ruinum.DynamicEvents.Scripts.Entries
{
    [Serializable]
    public class LogicalEntry : BaseEntry
    {
        public List<Criteria> Criterias = new List<Criteria>();
        public List<Modifier> Modifications = new List<Modifier>();

        public LogicalEntry(string name, string Id) : base(name, Id)
        {
        }

        public virtual void Execute()
        {
            if (Modifications.Count > 0)
            {
                //Refresh chosen facts
                for (int i = 0; i < Modifications.Count; i++)
                {
                    EventDatabaseHolder.Singleton.EventDatabase.TryFindFact(Modifications[i].Fact.ID, out Modifications[i].Fact);
                }

                for (int i = 0; i < Modifications.Count; i++)
                {
                    Modifications[i].Modify();
                }
            }
        }

        public bool CheckEntires()
        {
            //Refresh chosen facts
            for (int i = 0; i < Criterias.Count; i++)
            {
                EventDatabaseHolder.Singleton.EventDatabase.TryFindFact(Criterias[i].Fact.ID, out Criterias[i].Fact);
            }

            for (int i = 0; i < Criterias.Count; i++)
            {
                if (!Criterias[i].CheckCriteria()) return false;
            }

            return true;
        }
    }
}
