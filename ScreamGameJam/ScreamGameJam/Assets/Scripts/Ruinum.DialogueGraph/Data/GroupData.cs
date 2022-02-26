using System;
using UnityEngine;


namespace Ruinum.DialogueGraph.Scripts.Data
{
    [Serializable]
    public class GroupData
    {
        public string Name;
        public string ID;
        public Vector2 Position;

        public GroupData(string name, string id, Vector2 position)
        {
            Name = name;
            ID = id;
            Position = position;
        }
    }
}