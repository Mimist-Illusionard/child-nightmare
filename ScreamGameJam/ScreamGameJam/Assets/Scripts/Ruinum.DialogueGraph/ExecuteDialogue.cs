using Ruinum.DialogueGraph.Scripts.Data;
using UnityEngine;


public class ExecuteDialogue : MonoBehaviour
{
    public Dialogue Dialogue;

    public void StartDialogue()
    {
        Dialogue.Execute();
    }
}
