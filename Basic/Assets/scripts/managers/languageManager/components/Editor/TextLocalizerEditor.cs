#if UNITY_EDITOR

using Global.Components.Localization;
using Global.Managers.Datas;
using UnityEditor;
using UnityEngine;

namespace Global.EditorScripts.Drawers
{
    [CustomEditor(typeof(TextLocalizer))]
    public class TextLocalizerEditor : Editor
    {
        private const int NON_INIT = -1;

        private readonly GUIStyle errorStyle = new GUIStyle(EditorStyles.label);
        private static LocalizationData data;

        private SerializedProperty id;

        private LocalizationStatusType statusType = LocalizationStatusType.NonInit;

        private void OnEnable()
        {
            errorStyle.normal.textColor = Color.red;
            id = serializedObject.FindProperty("id");
        }

        public override void OnInspectorGUI()
        {
            TryFindData();
            serializedObject.Update();

            // data can be null
            if (data != null)
            {
                if (id.intValue == NON_INIT)
                {
                    statusType = LocalizationStatusType.NonInit;
                    id.intValue = data.GetNewValueID();
                }

                //EditorGUI.PropertyField(idRect, property.FindPropertyRelative("id"), GUIContent.none);
                //string str = data.GetTextByIDDef(property.FindPropertyRelative("id").intValue);
                //EditorGUI.LabelField(textRect, property.name + ": " + str);
            }
            else
            {
                EditorGUILayout.LabelField("error : localization data not found", errorStyle);
            }

            serializedObject.ApplyModifiedProperties();
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

    internal enum LocalizationStatusType
    {
        NonInit,
        WaitingToInit,
        Initialized,
        Refreshing
    }
}
#endif
