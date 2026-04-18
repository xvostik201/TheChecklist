using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CockpitElementData", menuName = "ScriptableObjects/Data/CockpitElementData")]
public class CockpitElementData : ScriptableObject
{
    [Header("Identification")]
    [Tooltip("Unique key to identify this element in the registry (e.g., Lever_Fuel_Left).")]
    [SerializeField] private string _elementID;
    public string ElementID => _elementID;
    
    [Tooltip("The display name shown to the player during interaction.")]
    [SerializeField] private string _elementName;
    public string ElementName => _elementName;
    
    [Header("Visual Settings")]
    [Tooltip("Defines the mechanical behavior of the element.")]
    [SerializeField] private CockpitElementType _elementType;
    public CockpitElementType ElementType => _elementType;

    [Tooltip("Duration of the movement or rotation animation in seconds.")]
    [Range(0.01f, 2f)]
    [SerializeField] private float _animationDuration = 0.3f;
    public float AnimationDuration => _animationDuration;
    
    [Tooltip("Target rotation angles relative to the starting rotation (Used for Levers).")]
    [SerializeField] private Vector3 _targetRotation;
    public Vector3 TargetRotation => _targetRotation;

    [Tooltip("Relative offset along the Z-axis (Used for Buttons).")]
    [SerializeField] private float _targetPositionZ;
    public float TargetPositionZ => _targetPositionZ;
    
    [Tooltip("The minimum allowed rotation angle (Used for Dragging/Thrust).")]
    [SerializeField] private float _minRotation = -10f;
    public float MinRotation => _minRotation;
    
    [Tooltip("The maximum allowed rotation angle (Used for Dragging/Thrust).")]
    [SerializeField] private float _maxRotation = 45f;
    public float MaxRotation => _maxRotation;

    [Tooltip("Multiplier for drag sensitivity. Higher values mean faster movement (Used for Dragging).")]
    [SerializeField, Range(0.1f, 2f)] private float _dragSpeed = 2f;
    public float DragSpeed => _dragSpeed;
}