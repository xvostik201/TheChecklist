using TheChecklist.Core.CockpitElements;
using TheChecklist.Core.Data;
using UnityEditor;


namespace TheChecklist.Editor
{
    [CustomEditor(typeof(CockpitElementData))]
    public class CockpitElementEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            DrawPropertiesExcluding(serializedObject,
                "_targetRotation", "_targetPosition", 
                "_minRotation", "_maxRotation", "_dragSpeed", "_animationDuration");
            
    
            CockpitElementData data = (CockpitElementData)target;
            
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Specific settings", EditorStyles.boldLabel);
            
            switch (data.ElementType)
            {
                case CockpitElementType.Button:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetPosition"),
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_animationDuration"), 
                        true);
                    EditorGUILayout.HelpBox($"Current element type: BUTTON", MessageType.Info);
                    break;
                case CockpitElementType.Lever:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetRotation"), 
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_animationDuration"),
                        true); 
                    EditorGUILayout.HelpBox($"Current element type: LEVER", MessageType.Info);
                    
                    break;
                case CockpitElementType.Dragging:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_minRotation"),
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_maxRotation"),
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_dragSpeed"),
                        true);
                        
                    EditorGUILayout.HelpBox($"Current element type: DRAGGING", MessageType.Info);
                    break;
                case CockpitElementType.Clipboard:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_animationDuration"),
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetRotation"),
                        true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_targetPosition"),
                        true);
                    break;
            }
            
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}

