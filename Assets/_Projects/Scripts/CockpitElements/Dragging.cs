using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragging : BaseCockpitElement
{
    private float _currentRotation;

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
    }
    
    public float GetNormalizedValue()
    {
        return Mathf.InverseLerp(_data.MinRotation, _data.MaxRotation, _currentRotation);
    }
}
