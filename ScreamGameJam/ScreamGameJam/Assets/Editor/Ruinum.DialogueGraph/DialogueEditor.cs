using UnityEngine;
using UnityEditor;

using Ruinum.DialogueGraph.Scripts.Data;
using Ruinum.DialogueGraph.Editor.Graph;


namespace Ruinum.DialogueGraph.Editor
{
    [CustomEditor(typeof(Dialogue))]
    public class DialogueEditor : UnityEditor.Editor
    {
        [SerializeField] private Dialogue _dialogue;

        public override void OnInspectorGUI()
        {
            _dialogue = (Dialogue)target;

            serializedObject.Update();

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("This is a simple dialogue.", MessageType.Info);

            EditorGUILayout.BeginHorizontal("box");
            if (GUILayout.Button("Graph"))
            {
                DialogueGraphEditorWindow.Open(_dialogue, _dialogue.Nodes, _dialogue.Groups);
            }

            if (GUILayout.Button("Clear Graph"))
            {
                _dialogue.Nodes.Clear();
                _dialogue.Groups.Clear();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}