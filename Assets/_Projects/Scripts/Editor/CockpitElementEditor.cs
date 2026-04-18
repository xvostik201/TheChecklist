using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CockpitElementData))]
public class CockpitElementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        DrawPropertiesExcluding(serializedObject,
            "_targetRotation", "_targetPosition", 
            "_minRotation", "_maxRotation", "_dragSpeed");

        CockpitElementData data = (CockpitElementData)target;
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Specific settings", EditorStyles.boldLabel);
        
        switch (data.ElementType)
        {
            case CockpitElementType.Button:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetPositionZ"), 
                    true);
                EditorGUILayout.HelpBox($"Current element type: BUTTON", MessageType.Info);
                break;
            case CockpitElementType.Lever:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetRotation"), 
                    true);
                EditorGUILayout.HelpBox($"Current element type: LEVER", MessageType.Info);
                
                break;
            case CockpitElementType.Dragging:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_minRotation"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_maxRotation"), true);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_dragSpeed"), true);
                    
                EditorGUILayout.HelpBox($"Current element type: DRAGGING", MessageType.Info);
                break;
        }
        
        
        serializedObject.ApplyModifiedProperties();
    }
}
