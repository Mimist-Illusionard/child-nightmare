using Ruinum.DialogueGraph.Scripts.Node;
using UnityEngine;


public class DialogueNodeLogic : NodeLogicBase
{
    private string _text;

    public override void GenerateFields(SerializedDictionaryString fields)
    {
        string test = "";
        fields.TryGetValue("Text", out test);

        _text = test;
    }

    public override void Logic()
    {
        Debug.Log($"Dialogue node: {_text}");
    }
}