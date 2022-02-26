using Ruinum.DialogueGraph.Scripts.Node;
using UnityEngine;


public class EndNodeLogic : NodeLogicBase
{
    public override void GenerateFields(SerializedDictionaryString fields)
    {
    }

    public override void Logic()
    {
        Debug.Log("Ending dialogue");
    }
}