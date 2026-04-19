using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TheChecklist.CockpitElements;
using TheChecklist.Installers;

public class Lever : BaseCockpitElement, IToggleable
{
    private Vector3 _startRotation;

    public event Action<bool> OnStateChanged;
    public bool IsActive => _isActive;

    protected override void Awake()
    {
        base.Awake();
        _startRotation = transform.localEulerAngles;
    }

    public override void OnInteract()
    {
        _isActive = !_isActive;

        AnimateLever();
        
        OnStateChanged?.Invoke(_isActive);
        // Debug.Log($"{_elementData.ElementName} is now {(_isActive ? "ON" : "OFF")}");
    }

    private void AnimateLever()
    {
        Vector3 finalRotation = _isActive ? _elementData.TargetRotation : _startRotation;

        transform.DOLocalRotate(finalRotation,  _elementData.AnimationDuration).SetEase(Ease.Linear);
    }
}
