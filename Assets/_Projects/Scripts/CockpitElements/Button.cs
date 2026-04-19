using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Button : BaseCockpitElement, IToggleable
{
    private float _startLocalPositonZ;
    private float _targetLocalPositonZ;
    
    public bool IsActive => _isActive;
    public event Action<bool> OnStateChanged;

    protected override void Awake()
    {
        base.Awake();
        _startLocalPositonZ = transform.localPosition.z;
        if(_elementData != null)  _targetLocalPositonZ = _startLocalPositonZ + _elementData.TargetPositionZ;
    }
    public override void OnInteract()
    {
        _isActive = !_isActive;

        AnimateButton();
        
        OnStateChanged?.Invoke(_isActive);
        // Debug.Log($"{_elementData.ElementName} is now {(_isActive ? "ON" : "OFF")}");
    }

    private void AnimateButton()
    {
        float finalRotation = _isActive ? _targetLocalPositonZ : _startLocalPositonZ;

        transform.DOLocalMoveZ(finalRotation,  _elementData.AnimationDuration).SetEase(Ease.Linear);
    }
}
