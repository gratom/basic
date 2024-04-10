#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using Global.Components.Localization;
using Global.Managers.Datas;
using UnityEditor;
using UnityEngine;

namespace Global.EditorScripts.Drawers
{

    [CustomPropertyDrawer(typeof(StringLocalizer))]
    public class StringLocalizerDrawer : PropertyDrawer
    {
        private readonly GUIStyle errorStyle = new GUIStyle(EditorStyles.label);
        private static LocalizationData data;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            errorStyle.normal.textColor = Color.red;

            EditorGUI.BeginProperty(position, label, property);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            Rect idRect = new Rect(position.x, position.y, 40, position.height);
            Rect textRect = new Rect(position.x + 45, position.y, position.width, position.height);

            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(idRect, property.FindPropertyRelative("id"), GUIContent.none);
            string str = "";

            TryFindData();

            if (data != null)
            {
                str = data.GetTextByIDDef(property.FindPropertyRelative("id").intValue);
                EditorGUI.LabelField(textRect, property.name + ": " + str);
            }
            else
            {
                EditorGUILayout.LabelField("error : localization data not found", errorStyle);
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        private static void TryFindData()
        {
            const string filter = "t:LocalizationData";

            if (data == null)
            {
                string[] guid = AssetDatabase.FindAssets(filter);
                if (guid != null && guid.Length > 0)
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(guid[0]); //only first will be noticed
                    if (!string.IsNullOrEmpty(assetPath))
                    {
                        data = AssetDatabase.LoadAssetAtPath<LocalizationData>(assetPath);
                    }
                }
            }
        }

    }
}
#endif
