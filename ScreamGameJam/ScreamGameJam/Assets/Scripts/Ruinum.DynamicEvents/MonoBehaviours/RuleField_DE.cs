using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Structs;


namespace Ruinum.DynamicEvents.Scripts
{
    public class RuleField_DE : MonoBehaviour
    {
        public RuleField RuleField;

        public void Awake()
        {
            RuleField.Initialize();
        }
    }
}