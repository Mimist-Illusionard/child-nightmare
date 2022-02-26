using System;
using System.Collections.Generic;

using Ruinum.DialogueGraph.Scripts.Data;


namespace Ruinum.DialogueGraph.Scripts.Node
{
    public class NodeLogicExecuter
    {
        private List<GraphNodeData> _nodeDatas;
        private List<NodeLogicBase> _nodeLogics;

        private bool _isInitialize;

        public NodeLogicExecuter(List<GraphNodeData> NodeDatas)
        {
            _nodeDatas = NodeDatas;
            _nodeLogics = new List<NodeLogicBase>();

            InitializeLogic();
        }

        private void InitializeLogic()
        {
            GraphNodeData currentNode = null;

            //Find start node
            for (int i = 0; i < _nodeDatas.Count; i++)
            {
                var nodeData = _nodeDatas[i];

                if (nodeData.Type == NodeType.Start)
                {
                    _nodeLogics.Add(GenerateNodeLogic(nodeData));
                    currentNode = nodeData;
                    break;
                }
            }

            int nodeCount = 0;
            //Loop for each node and generate node logic
            while (currentNode.Type != NodeType.End && nodeCount <= _nodeDatas.Count + 2)
            {
                foreach (var nodeData in _nodeDatas)
                {
                    if (nodeData.ID == currentNode.GetOutputPort().ConnectedNodeID)
                    {
                        _nodeLogics.Add(GenerateNodeLogic(nodeData));
                        currentNode = nodeData;

                        if (currentNode.Type == NodeType.End)
                        {
                            _isInitialize = true;                            
                            return;
                        }
                    }
                }

                nodeCount++;
            }

            if (!_isInitialize) UnityEngine.Debug.LogError($"Initialize of dialogue ended with error: Dialogue not connected to <b>EndNode</b>");
        }

        public void Logic()
        {
            if (!_isInitialize) return;

            for (int i = 0; i < _nodeLogics.Count; i++)
            {
                var nodeLogic = _nodeLogics[i];
                nodeLogic.Logic();
            }
        }

        private NodeLogicBase GenerateNodeLogic(GraphNodeData nodeData)
        {
            Type logicType = Type.GetType($"{nodeData.Type}NodeLogic");

            NodeLogicBase logic = (NodeLogicBase)Activator.CreateInstance(logicType);

            logic.Type = nodeData.Type;                       

            logic.GenerateFields(nodeData.Fields);

            return logic;
        }
    }
}