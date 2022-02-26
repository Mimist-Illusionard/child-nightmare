using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

using Ruinum.DialogueGraph.Editor.Elements;
using Ruinum.DialogueGraph.Editor.Utility;


public class StartNode : GraphNodeBase
{
    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);
        NodeName = "Start Node";
        SpellNodeType = NodeType.Start;
    }

    public override void Draw()
    {
        base.Draw();

        capabilities = ~Capabilities.Deletable;
        capabilities &= ~Capabilities.Resizable;

        var outputPort = NodeElementsUtility.CreatePort(this, "Output");

        outputContainer.Add(outputPort);
        Ports.Add(outputPort);

        Label label = new Label("This is Start Node \nConnect this to next Node");

        CustomDataContainer.Add(label);

        RefreshExpandedState();
    }
}