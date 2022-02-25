using Ruinum.DialogueGraph.Scripts.Node;
using UnityEngine;


public class StartNodeLogic : NodeLogicBase
{
    public override void GenerateFields(SerializedDictionaryString fields)
    {
    }

    public override void Logic()
    {
        Debug.Log("Starting dialogue");
    }
}