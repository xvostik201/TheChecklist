using System;
using UnityEngine;

public class Dragging : BaseCockpitElement, INormalizedElement
{
    private float _currentRotation;

    public float NormalizedValue => GetNormalizedValue();
    public event Action<float> OnValueChanged;

    protected override void Start()
    {
        base.Start();
        
        _currentRotation = _data != null ? _data.MinRotation : 0f;
        transform.localRotation = Quaternion.Euler(_currentRotation, 0, 0);
    }

    public override void OnInteract()
    {
        
    }

    public void UpdateHandlePosition(float deltaY)
    {
        _currentRotation += deltaY * _data.DragSpeed;
        _currentRotation = Mathf.Clamp(_currentRotation, _data.MinRotation, _data.MaxRotation);
        transform.localRotation = Quaternion.Euler(_currentRotation, 0, 0);
        
        OnValueChanged?.Invoke(NormalizedValue);
        Debug.Log($"{_data.ElementName} is now normalized value {NormalizedValue}");
    }
    
    public float GetNormalizedValue()
    {
        return Mathf.InverseLerp(_data.MinRotation, _data.MaxRotation, _currentRotation);
    }
}
