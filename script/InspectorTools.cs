// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;


// [PropertyAttribute]
// public class InspectorTools : PropertyAttribute
// {
//     // A public field that will be exposed in the Inspector
//     public int field;

//     // Use the PropertyDrawer attribute to create a custom property drawer for the InspectorTools attribute
//     [PropertyDrawer]
//     public class InspectorToolsDrawer : PropertyDrawer
//     {
//         public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//         {
//             // Get the value of the "field" property
//             int field = property.FindPropertyRelative("field").intValue;

//             // Draw a field for the "field" property
//             field = EditorGUI.IntField(position, label, field);

//             // Set the value of the "field" property
//             property.FindPropertyRelative("field").intValue = field;
//         }
//     }
// }

