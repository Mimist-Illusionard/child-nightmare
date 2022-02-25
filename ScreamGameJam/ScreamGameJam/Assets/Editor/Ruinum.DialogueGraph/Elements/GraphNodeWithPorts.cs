using UnityEditor.Experimental.GraphView;

using Ruinum.DialogueGraph.Editor.Utility;


namespace Ruinum.DialogueGraph.Editor.Elements
{
    public class GraphNodeWithPorts : GraphNodeBase
    {
        public override void Draw()
        {
            base.Draw();

            var inputPort = NodeElementsUtility.CreatePort(this, "Input", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
            var outputPort = NodeElementsUtility.CreatePort(this, "Output");

            inputContainer.Add(inputPort);
            outputContainer.Add(outputPort);

            Ports.Add(inputPort);
            Ports.Add(outputPort);
        }
    }
}