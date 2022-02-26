using System.Collections.Generic;
using System;

using UnityEngine;


namespace Ruinum.DialogueGraph.Scripts.Data
{
    [Serializable]
    public class GraphNodeData
    {
        public string Name;
        public string ID;
        public NodeType Type;
        public string GroupID;
        public Vector2 Position;

        public SerializedDictionaryString Fields = new SerializedDictionaryString();
        public List<NodePortData> Ports;

        public NodePortData GetOutputPort()
        {
            for (int i = 0; i < Ports.Count; i++)
            {
                var port = Ports[i];
                if (port.Name == "Output")
                {
                    return port;
                }
            }

            return null;
        }

        public List<NodePortData> GetAllOutputPorts()
        {
            var outputPorts = new List<NodePortData>();

            for (int i = 0; i < Ports.Count; i++)
            {
                var port = Ports[i];
                if (port.Direction.ToString() == "Output")
                {
                    outputPorts.Add(port);
                }
            }

            return outputPorts;
        }
    }
}