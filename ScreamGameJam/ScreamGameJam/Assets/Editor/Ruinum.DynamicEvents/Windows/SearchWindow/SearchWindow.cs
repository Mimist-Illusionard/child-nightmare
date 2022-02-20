using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;


namespace Ruinum.DynamicEvents.Editor.Windows
{
    //Generic search window. 
    public class SearchWindow<T> : ISearchWindow
    {
        public List<T> List = new List<T>();
        public T SelectedItem;
        public int ItemIndex;
        public Action<T> Action;

        public string Value;

        public void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("Search:", EditorStyles.boldLabel);
            Value = EditorGUILayout.TextField(Value);
            EditorGUILayout.EndHorizontal();

            GetSearchResults();

            EditorGUILayout.EndVertical();
        }

        public virtual void GetSearchResults()
        {
            if (List.Count <= 0) EditorGUILayout.HelpBox("List is empty or not setted", MessageType.Error);
            for (int i = 0; i < List.Count; i++)
            {
                if (Value == null)
                {
                    EditorGUILayout.BeginHorizontal("box");
                    EditorGUILayout.LabelField(List[i].ToString());

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
                    EditorGUILayout.LabelField(List[i].ToString());

                    if (GUILayout.Button("+", GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20)))
                    {
                        SelectedItem = List[i];
                        Action?.Invoke(SelectedItem);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        public void SetValues(List<T> list, Action<T> action)
        {
            List = list;
            Action = action;
        }
    }
}