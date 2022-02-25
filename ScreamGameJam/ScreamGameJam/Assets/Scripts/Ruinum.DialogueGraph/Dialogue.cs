using System;
using System.Collections.Generic;

using UnityEngine;

using Ruinum.DialogueGraph.Scripts.Node;


namespace Ruinum.DialogueGraph.Scripts.Data
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Ruinum/DialogueGraph/Dialogue")]
    [Serializable]
    public class Dialogue : ScriptableObject
    {
        public List<GraphNodeData> Nodes = new List<GraphNodeData>();
        public List<GroupData> Groups = new List<GroupData>();
        public Action<string> OnExecuteDialogue;

        public void Execute()
        {
            var nodeLogicExecuter = new NodeLogicExecuter(Nodes);
            nodeLogicExecuter.Logic();
        }
    }
}