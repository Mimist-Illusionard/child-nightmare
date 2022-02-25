using Ruinum.DialogueGraph.Scripts.Data;
using UnityEngine;


public class ExecuteDialogue : MonoBehaviour
{
    public Dialogue Dialogue;

    private void Start()
    {
        Dialogue.Execute();
    }
}
