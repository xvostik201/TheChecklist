using System;
using UnityEngine;

public class Dragging : BaseCockpitElement, INormalizedElement
{
    private float _currentRotation;

    public float NormalizedValue => GetNormalizedValue();
    public event Action<float> OnValueChanged;

    protected override void Awake()
    {
        base.Awake();
        
        _currentRotation = _elementData != null ? _elementData.MinRotation : 0f;
        transform.localRotation = Quaternion.Euler(_currentRotation, 0, 0);
    }

    public override void OnInteract()
    {
        
    }

    public void UpdateHandlePosition(float deltaY)
    {
        _currentRotation += deltaY * _elementData.DragSpeed;
        _currentRotation = Mathf.Clamp(_currentRotation, _elementData.MinRotation, _elementData.MaxRotation);
        transform.localRotation = Quaternion.Euler(_currentRotation, 0, 0);
        
        OnValueChanged?.Invoke(NormalizedValue);
        // Debug.Log($"{_elementData.ElementName} is now normalized value {NormalizedValue}");
    }
    
    public float GetNormalizedValue()
    {
        return Mathf.InverseLerp(_elementData.MinRotation, _elementData.MaxRotation, _currentRotation);
    }
}
