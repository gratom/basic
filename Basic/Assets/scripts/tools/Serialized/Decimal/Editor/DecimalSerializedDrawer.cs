#if UNITY_EDITOR

namespace Tools
{
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(DecimalSerialized))]
    public class DecimalWrapperPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty decimalStringProp = property.FindPropertyRelative("data");

            decimal value = decimal.TryParse(decimalStringProp.stringValue, out decimal result) ? result : 0;

            EditorGUI.BeginProperty(position, label, property);
            string newValue = EditorGUI.TextField(position, label, value.ToString());
            decimalStringProp.stringValue = newValue;
            EditorGUI.EndProperty();
        }
    }
}
#endif
