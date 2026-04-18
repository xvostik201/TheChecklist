using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Lever : BaseCockpitElement
{
    private Vector3 _startRotation;
    protected override void Start()
    {
        base.Start();
        _startRotation = transform.localEulerAngles;
    }

    public override void OnInteract()
    {
        _isActive = !_isActive;

        Vector3 finalRotation = _isActive ? _data.TargetRotation : _startRotation;
        
        transform.DOLocalRotate(finalRotation,  _data.AnimationDuration).SetEase(Ease.Linear);
    }
}
