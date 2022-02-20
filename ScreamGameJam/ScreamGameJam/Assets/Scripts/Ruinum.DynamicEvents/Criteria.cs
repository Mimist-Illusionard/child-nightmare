using System;
using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Scripts
{
    [Serializable]
    public class Criteria
    {
        public FactEntry Fact;
        public EqualType Type;
        public int Value;

        public Criteria(string name, string id)
        {
        }

        public bool CheckCriteria()
        {
            switch (Type)
            {
                case EqualType.None:
                    return false;
                case EqualType.Greater:
                    if (Fact.Value > Value) return true;
                    break;
                case EqualType.GreaterOrEqual:
                    if (Fact.Value >= Value) return true;
                    break;
                case EqualType.Less:
                    if (Fact.Value < Value) return true;
                    break;
                case EqualType.LessOrEqual:
                    if (Fact.Value <= Value) return true;
                    break;
                default:
                    return false;
            }

            return false;
        }

        [Serializable]
        public enum EqualType
        {
            None = 0,
            Greater = 1,
            GreaterOrEqual = 2,
            Less = 3,
            LessOrEqual = 4
        }
    }
}
