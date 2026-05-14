using System;
using DG.Tweening;
using TheChecklist.Interfaces;
using UnityEngine;

namespace TheChecklist.Features.Cockpit.Elements
{
    public class Button : BaseCockpitElement, IToggleableElement
    {
        private Vector3 _startLocalPosition;
        private Vector3 _targetLocalPosition;
    
        public bool IsActive => _isActive;
        public event Action<bool> OnStateChanged;

        protected override void Awake()
        {
            base.Awake();
            _startLocalPosition = transform.localPosition;
            if(_elementData != null)  _targetLocalPosition = _elementData.TargetPosition;
            
        }

        
        public override void OnInteract()
        {
            _isActive = !_isActive;

            AnimateButton();
        
            OnStateChanged?.Invoke(_isActive);
            
            _audioProvider.PlaySound3D(transform.position, _elementData.AudioClipID);
            // Debug.Log($"{_elementData.ElementName} is now {(_isActive ? "ON" : "OFF")}");
        }

        private void AnimateButton()
        {
            Vector3 finalPositionZ = _isActive ? _targetLocalPosition : _startLocalPosition;

            transform.DOLocalMove(finalPositionZ,  _elementData.AnimationDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
            });
        }
    }
}

