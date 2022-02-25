using System;

using UnityEditor.Experimental.GraphView;


namespace Ruinum.DialogueGraph.Scripts.Data
{
    [Serializable]
    public class NodePortData
    {
        public string Name;
        public string ID;
        public Direction Direction;
        public string ConnectedNodeID;

        public NodePortData(string name, string id, Direction direction, string connectedNodeID)
        {
            Name = name;
            ID = id;
            Direction = direction;
            ConnectedNodeID = connectedNodeID;
        }
    }
}