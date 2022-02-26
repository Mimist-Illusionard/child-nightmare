using UnityEngine;
using UnityEngine.UIElements;

using Ruinum.DialogueGraph.Editor.Elements;
using Ruinum.DialogueGraph.Editor.Utility;
using Ruinum.DialogueGraph.Scripts.Data;


public class DialogueNode : GraphNodeWithPorts
{
    private TextField _titleField;
    public string Text;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Dialogue Node";
        SpellNodeType = NodeType.Dialogue;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Text");
        _titleField = NodeElementsUtility.CreateTextField("Write here your dialogue");

        CustomDataContainer.Insert(0, _titleField);

        _titleField.AddClasses
        (
            "dg-node__textfield",
            "dg-node__quote-textfield"
        );

        CustomDataContainer.Add(label);
        CustomDataContainer.Add(_titleField);
    }

    public override void Load(GraphNodeData nodeData)
    {
        base.Load(nodeData);

        nodeData.Fields.TryGetValue("Text", out Text);

        if (Text != null)
            _titleField.SetValueWithoutNotify(Text.ToString());
    }

    public override GraphNodeData SaveNode()
    {
        GraphNodeData.Fields.Add("Text", _titleField.text);

        return base.SaveNode();
    }
}