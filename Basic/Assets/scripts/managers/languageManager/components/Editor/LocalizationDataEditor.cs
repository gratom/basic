#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Global.Managers.Datas
{
    [CustomEditor(typeof(LocalizationData))]
    public class LocalizationDataEditor : Editor
    {
        private SerializedProperty allLanguages;
        private void OnEnable()
        {
            allLanguages = serializedObject.FindProperty("allLanguages");
        }

        private void InitLanguages()
        {
            bool[] checkArray = new bool [Enum.GetNames(typeof(GT.Language)).Length];
            for (int i = 0; i < allLanguages.arraySize; i++)
            {
                SerializedProperty languageContainer = allLanguages.GetArrayElementAtIndex(i);
                SerializedProperty language = languageContainer.FindPropertyRelative("language");
                int index = language.enumValueIndex;
                if (checkArray[index])
                {
                    allLanguages.DeleteArrayElementAtIndex(i);
                    i--;
                    continue;
                }
                checkArray[index] = true;
            }
            for (int i = 0; i < checkArray.Length; i++)
            {
                if (!checkArray[i])
                {
                    allLanguages.InsertArrayElementAtIndex(allLanguages.arraySize);
                    SerializedProperty languageContainer = allLanguages.GetArrayElementAtIndex(allLanguages.arraySize - 1);
                    SerializedProperty language = languageContainer.FindPropertyRelative("language");
                    language.enumValueIndex = i;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            InitLanguages();

            EditorGUILayout.LabelField("All Languages", EditorStyles.boldLabel);
            if (GUILayout.Button(allLanguages.isExpanded ? "hide" : "show"))
            {
                allLanguages.isExpanded = !allLanguages.isExpanded;
            }
            if (allLanguages.isExpanded)
            {
                EditorGUI.indentLevel++;
                for (int i = 0; i < allLanguages.arraySize; i++)
                {
                    SerializedProperty languageContainer = allLanguages.GetArrayElementAtIndex(i);
                    SerializedProperty isActive = languageContainer.FindPropertyRelative("isActive");

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(((GT.Language)languageContainer.FindPropertyRelative("language").enumValueIndex).ToString());
                    isActive.boolValue = EditorGUILayout.Toggle("", isActive.boolValue);
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUI.indentLevel--;
            }


            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif
