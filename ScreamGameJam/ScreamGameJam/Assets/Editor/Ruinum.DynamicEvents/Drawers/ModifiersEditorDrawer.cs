using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Ruinum.DynamicEvents.Scripts.Entries;
using Ruinum.DynamicEvents.Scripts;
using Ruinum.DynamicEvents.Editor.Utilites;


namespace Ruinum.DynamicEvents.Editor.Drawers
{
    public class ModifiersEditorDrawer
    {
        public List<Modifier> Modifiers;
        public List<FactEntry> Facts;
        public int ItemIndex;

        public SearchBar<Modifier> ModifierSearch = new SearchBar<Modifier>();

        public void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Modifiers:");
            ModifierSearch.DrawPlusButton(Modifiers);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical("box");
            for (int i = 0; i < Modifiers.Count; i++)
            {
                if (Modifiers.Count < 0) break;

                EditorGUILayout.BeginHorizontal();
                if (Modifiers[i].Fact != null)
                {
                    EditorGUILayout.LabelField(Modifiers[i].Fact.Name);
                }
                else
                    EditorGUILayout.LabelField("NONE", EditorStyles.boldLabel);

                Modifiers[i].Type = (Modifier.ModifierType)EditorGUILayout.EnumPopup(Modifiers[i].Type);
                Modifiers[i].Value = EditorGUILayout.IntField(Modifiers[i].Value, GUILayout.MaxWidth(80f));

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("+", GUI.skin.label))
                {
                    var window = EditorExtentions.CreateSearchWindowBaseEntry(typeof(FactEntry));
                    window.SetValues(Facts, (selection) => { Modifiers[ItemIndex].Fact = selection as FactEntry; });
                    ItemIndex = i;
                }

                if (GUILayout.Button("-", GUI.skin.label))
                {
                    Modifiers.Remove(Modifiers[i]);
                }

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndVertical();
        }

        public void SetValues(List<Modifier> modifiers, List<FactEntry> factEntries)
        {
            Modifiers = modifiers;
            Facts = factEntries;
        }
    }
}