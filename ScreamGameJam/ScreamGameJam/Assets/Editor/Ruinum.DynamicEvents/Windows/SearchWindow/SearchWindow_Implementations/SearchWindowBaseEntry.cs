using UnityEditor;
using UnityEngine;

using Ruinum.DynamicEvents.Scripts.Entries;


namespace Ruinum.DynamicEvents.Editor.Windows
{
    public class SearchWindowBaseEntry : SearchWindow<BaseEntry>
    {
        public override void GetSearchResults()
        {
            if (List.Count <= 0) EditorGUILayout.HelpBox("List is empty or not setted", MessageType.Error);
            for (int i = 0; i < List.Count; i++)
            {
                if (Value == null)
                {
                    EditorGUILayout.BeginHorizontal("box");
                    EditorGUILayout.LabelField(List[i].Name.ToString());

                    if (GUILayout.Button("+", GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20)))
                    {
                        SelectedItem = List[i];
                        Action?.Invoke(SelectedItem);
                    }
                    EditorGUILayout.EndHorizontal();
                }
                else if (Value != null && List[i].ToString().ToLower().Contains(Value.ToLower()))
                {
                    EditorGUILayout.BeginHorizontal("box");
                    EditorGUILayout.LabelField(List[i].Name.ToString());

                    if (GUILayout.Button("+", GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20)))
                    {
                        SelectedItem = List[i];
                        Action?.Invoke(SelectedItem);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}
