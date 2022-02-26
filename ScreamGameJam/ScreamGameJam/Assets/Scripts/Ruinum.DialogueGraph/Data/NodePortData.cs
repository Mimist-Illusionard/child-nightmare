using System;


namespace Ruinum.DialogueGraph.Scripts.Data
{
    [Serializable]
    public class NodePortData
    {
        public string Name;
        public string ID;
        public DataDirection Direction;
        public string ConnectedNodeID;

        public NodePortData(string name, string id, DataDirection direction, string connectedNodeID)
        {
            Name = name;
            ID = id;
            Direction = direction;
            ConnectedNodeID = connectedNodeID;
        }
    }
}
public enum DataDirection
{
    None = 0,
    Output = 1,
    Input = 2
}