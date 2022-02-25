using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Structs;


namespace Ruinum.DynamicEvents.Scripts
{
    public class FactField_DE : MonoBehaviour
    {
        public FactField FactField;

        public void Start()
        {
            FactField.Initialize();
        }

        public void IncreaseOne(int i)
        {
            FactField.Initialize();
            FactField.FactEntry.Value += i;
        }
    }
}