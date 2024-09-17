#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

namespace Tools
{
    [CustomPropertyDrawer(typeof(TimeSpanSerialized))]
    public class TimeSpanSerializedPropertyDrawer : PropertyDrawer
    {
        // Define the height of the property drawer
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 6 + 10;
        }

        // Draw the property in the Inspector
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUIStyle boldLabelStyle = new GUIStyle(GUI.skin.label)
            {
                fontStyle = FontStyle.Bold
            };

            // Get the serialized fields
            SerializedProperty ticksProperty = property.FindPropertyRelative("ticks");

            // Parse the current TimeSpan value from ticks
            TimeSpan timeSpan = TimeSpan.FromTicks(ticksProperty.longValue);

            // Calculate positions for the input fields
            position.y += 10;
            Rect rectLabel = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(rectLabel, label.text + "   " + timeSpan.ToCustomString(), boldLabelStyle);

            Rect dayRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 1, position.width, EditorGUIUtility.singleLineHeight);
            Rect hourRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 2, position.width, EditorGUIUtility.singleLineHeight);
            Rect minuteRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 3, position.width, EditorGUIUtility.singleLineHeight);
            Rect secondRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 4, position.width, EditorGUIUtility.singleLineHeight);

            Rect totalMinuteRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 5, position.width, EditorGUIUtility.singleLineHeight);

            int days = timeSpan.Days;
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;
            double m = timeSpan.TotalMinutes;

            // Draw input fields for each component
            EditorGUI.BeginProperty(position, label, property);

            days = EditorGUI.IntField(dayRect, "Days", days);
            hours = EditorGUI.IntField(hourRect, "Hours", hours);
            minutes = EditorGUI.IntField(minuteRect, "Minutes", minutes);
            seconds = EditorGUI.IntField(secondRect, "Seconds", seconds);

            double newM = EditorGUI.DoubleField(totalMinuteRect, "Total minutes", m);

            if (newM != m)
            {
                TimeSpan newTimeSpanM = TimeSpan.FromMinutes(newM);
                ticksProperty.longValue = newTimeSpanM.Ticks;
                EditorGUI.EndProperty();
                return;
            }

            // Validate the input values
            if (seconds > 60)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes > 60)
            {
                minutes = 0;
                hours++;
            }
            if (hours > 24)
            {
                hours = 0;
                days++;
            }

            // Calculate the new TimeSpan and update the ticks
            TimeSpan newTimeSpan = new TimeSpan(days, hours, minutes, seconds);
            ticksProperty.longValue = newTimeSpan.Ticks;

            EditorGUI.EndProperty();
        }
    }
}
#endif
