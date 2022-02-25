using System.Collections.Generic;
using System;

using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

using Ruinum.DialogueGraph.Editor.Graph;
using Ruinum.DialogueGraph.Scripts.Data;
using Ruinum.DialogueGraph.Editor.Utility;


namespace Ruinum.DialogueGraph.Editor.Elements
{
    public class GraphNodeBase : UnityEditor.Experimental.GraphView.Node
    {
        protected DialogueGraphView GraphView;
        protected VisualElement CustomDataContainer;
        protected GraphNodeData GraphNodeData = new GraphNodeData();

        protected List<NodePortData> PortsData = new List<NodePortData>();
        protected List<Port> Ports = new List<Port>();

        public NodeType SpellNodeType;
        public string NodeName;
        public string ID;
        public string GroupID;

        public virtual void Initialize(Vector2 position, bool needGenerateGuid = true)
        {
            SetPosition(new Rect(position, Vector2.zero));

            NodeName = "Node";
            if (needGenerateGuid)
                GenerateGUID();

            mainContainer.AddToClassList("dg-node__main_container");
            extensionContainer.AddToClassList("dg-node__extension-container");
        }

        public virtual void Draw()
        {
            Label label = new Label(NodeName);

            titleContainer.Insert(0, label);

            label.AddClasses
            (
                "dg-node__textfield",
                "dg-node__filename-textfield",
                "dg-node__textfield__hidden"
            );

            CustomDataContainer = new VisualElement();
            CustomDataContainer.AddToClassList("dg-node__custom-data-container");

            extensionContainer.Add(CustomDataContainer);
        }

        public void AddInputNode(Port outputPort, GraphNodeBase inputNode)
        {
            PortsData.Add(new NodePortData(outputPort.portName, Guid.NewGuid().ToString(), Direction.Output, inputNode.ID));
        }

        public void SetGraphView(DialogueGraphView graphView)
        {
            GraphView = graphView;
        }

        public void GenerateGUID()
        {
            ID = Guid.NewGuid().ToString();
        }

        public bool TryGetPortConnectionByID(string id, out NodePortData result)
        {
            result = null;

            foreach (var portData in PortsData)
            {
                if (portData.ConnectedNodeID == id)
                {
                    result = portData;
                    return true;
                }
            }

            return false;
        }

        #region Save & Load Methods
        public virtual GraphNodeData SaveNode()
        {
            GraphNodeData.Name = NodeName;
            GraphNodeData.ID = ID;
            GraphNodeData.Type = SpellNodeType;
            GraphNodeData.Position = this.GetPosition().position;
            GraphNodeData.GroupID = GroupID;

            return GraphNodeData;
        }

        public List<NodePortData> SavePorts()
        {
            for (int i = 0; i < Ports.Count; i++)
            {
                var port = Ports[i];

                if (port.direction == Direction.Input)
                    PortsData.Add(new NodePortData("Input", Guid.NewGuid().ToString(), port.direction, ""));
            }

            return PortsData;
        }

        public virtual void Load(GraphNodeData nodeData)
        {
            NodeName = nodeData.Name;
            ID = nodeData.ID;
            SpellNodeType = nodeData.Type;
            GroupID = nodeData.GroupID;
        }

        public void LoadPorts(GraphNodeData nodeData)
        {
            List<NodePortData> outputPorts = new List<NodePortData>();

            foreach (var portData in nodeData.Ports)
            {
                if (portData.Direction == Direction.Output)
                {
                    outputPorts.Add(portData);
                }
            }

            foreach (var port in Ports)
            {
                if (port.direction == Direction.Output)
                {
                    foreach (var outputPort in outputPorts)
                    {
                        if (port.portName == outputPort.Name)
                        {
                            var connectedNode = GraphView.GetNodeByID(outputPort.ConnectedNodeID);

                            if (connectedNode == null) continue;

                            for (int i = 0; i < connectedNode.Ports.Count; i++)
                            {
                                var nodePort = connectedNode.Ports[i];

                                if (nodePort == null) continue;

                                if (nodePort.direction == Direction.Input)
                                {
                                    var edge = port.ConnectTo(nodePort);
                                    GraphView.AddElement(edge);

                                    AddInputNode(edge.output, connectedNode);

                                    connectedNode.RefreshPorts();
                                    port.node.RefreshPorts();
                                }
                            }                           
                        }
                    }
                }
            }
        }
        #endregion
    }
}