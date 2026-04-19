using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Lever : BaseCockpitElement, IToggleable
{
    private Vector3 _startRotation;

    public event Action<bool> OnStateChanged;
    public bool IsActive => _isActive;

    protected override void Start()
    {
        base.Start();
        _startRotation = transform.localEulerAngles;
    }

    public override void OnInteract()
    {
        _isActive = !_isActive;

        AnimateLever();
        
        OnStateChanged?.Invoke(_isActive);
        Debug.Log($"{_data.ElementName} is now {(_isActive ? "ON" : "OFF")}");
    }

    private void AnimateLever()
    {
        Vector3 finalRotation = _isActive ? _data.TargetRotation : _startRotation;

        transform.DOLocalRotate(finalRotation,  _data.AnimationDuration).SetEase(Ease.Linear);
    }
}
