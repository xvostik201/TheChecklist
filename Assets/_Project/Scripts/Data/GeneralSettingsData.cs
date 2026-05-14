using UnityEngine;

namespace TheChecklist.Data
{
    [CreateAssetMenu(fileName = "GeneralSettingsData", menuName = "ScriptableObjects/Data/GeneralSettingsData")]
    public class GeneralSettingsData : ScriptableObject
    {
        [SerializeField, Range(0, 1f)] private float _mouseSensitivity = 0.25f;
        public float MouseSensitivity => _mouseSensitivity;
    
        [SerializeField] private float _xRotationClamp = 90f;
        public float XRotationClamp => _xRotationClamp;

        [SerializeField] private float _draggingResistance = 4f;
        public float DraggingResistance => _draggingResistance;
    
        public readonly float ZeroResistance = 1f;
        
        [SerializeField, Range(0, 3f)] private float _zoomSensitivity = 1f;
        public float ZoomSensitivity => _zoomSensitivity;

        [SerializeField] private float _minFOV = 25f;
        public float MinFOV => _minFOV;
        
        [SerializeField] private float _maxFOV = 60f;
        public float MaxFOV => _maxFOV;
    }
}

