using System;


namespace Ruinum.DynamicEvents.Scripts.Entries
{
    [Serializable]
    public class FactEntry : BaseEntry
    {
        public int Value;

        public FactEntry(string name, string Id) : base(name, Id)
        {
        }
    }
}
