using System;
using UnityEngine;


namespace Ruinum.DynamicEvents.Scripts.Entries 
{
    [Serializable]
    public class BaseEntry
    {
        [SerializeField] public string Name;
        [SerializeField] public string ID;        

        public BaseEntry(string name, string Id)
        {
            Name = name;
            ID = Id;
        }
    }
}