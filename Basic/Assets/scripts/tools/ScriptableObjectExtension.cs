using UnityEngine;

namespace Tools
{
    public static class ScriptableObjectExtension
    {
        public static void Save(this ScriptableObject scriptableObject)
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(scriptableObject);
            UnityEditor.AssetDatabase.SaveAssets();
#endif
        }
    }
}