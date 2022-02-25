using System;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts
{
    [Serializable]
    public class Modifier
    {
        public FactEntry Fact;
        public ModifierType Type;
        public int Value;

        public Modifier(string value, string i)
        {
        }

        public void Modify()
        {
            //TODO: Write error message
            if (!EventDatabaseHolder.Singleton.EventDatabase.TryFindFact(Fact.ID, out var fact)) return;

            switch (Type)
            {
                case ModifierType.None:
                    break;
                case ModifierType.Plus:
                    fact.Value += Value;
                    break;
                case ModifierType.Minus:
                    fact.Value -= Value;
                    break;
                default:
                    break;
            }
        }

        public enum ModifierType
        {
            None = 0,
            Plus = 1,
            Minus = 2
        }
    }
}