using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Button : BaseCockpitElement
{
    private float _startLocalPositonZ;
    private float _targetLocalPositonZ;

    protected override void Start()
    {
        base.Start();
        
        _startLocalPositonZ = transform.localPosition.z;
        if(_data != null)  _targetLocalPositonZ = _startLocalPositonZ + _data.TargetPositionZ;
    }
    public override void OnInteract()
    {
        _isActive = !_isActive;

        float finalRotation = _isActive ? _targetLocalPositonZ : _startLocalPositonZ;
        
        transform.DOLocalMoveZ(finalRotation,  _data.AnimationDuration).SetEase(Ease.Linear);
    }
}
