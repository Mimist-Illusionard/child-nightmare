using System.Collections.Generic;

using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;

using Ruinum.DialogueGraph.Scripts.Data;
using Ruinum.DialogueGraph.Editor.Utility;


namespace Ruinum.DialogueGraph.Editor.Graph
{
    public class DialogueGraphEditorWindow : EditorWindow
    {
        private static ScriptableObject _scriptableObject;
        private static List<GraphNodeData> _nodes;
        private static List<GroupData> _groupes;
        private static DialogueGraphView _graphView;

        public static void Open(ScriptableObject scriptableObject, List<GraphNodeData> nodes, List<GroupData> groupes)
        {
            _scriptableObject = scriptableObject;
            _nodes = nodes;
            _groupes = groupes;

            GetWindow<DialogueGraphEditorWindow>($"Spell Graph Window");
        }

        public void OnEnable()
        {
            AddGraphView();
            AddToolbar();
        }

        private void AddGraphView()
        {
            _graphView = new DialogueGraphView(this, _nodes, _groupes);

            _graphView.StretchToParentSize();

            rootVisualElement.Add(_graphView);
        }

        private void AddToolbar()
        {
            Toolbar toolbar = new Toolbar();

            Button saveButton = NodeElementsUtility.CreateButton("Save", () =>
            {
                _graphView.Save();
            });

            toolbar.Add(saveButton);

            rootVisualElement.Add(toolbar);
        }

        public void Save()
        {
            EditorUtility.SetDirty(_scriptableObject);
        }
    }
}