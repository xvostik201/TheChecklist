using System;
using DG.Tweening;
using UnityEngine;
using TheChecklist.Interfaces;

namespace TheChecklist.Core.CockpitElements
{
    public class Lever : BaseCockpitElement, IToggleableElement
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
            
            _audioProvider.PlaySound3D(transform.position, _elementData.AudioClipID);
            // Debug.Log($"{_elementData.ElementName} is now {(_isActive ? "ON" : "OFF")}");
        }

        private void AnimateLever()
        {
            Vector3 finalRotation = _isActive ? _elementData.TargetRotation : _startRotation;

            transform.DOLocalRotate(finalRotation,  _elementData.AnimationDuration).SetEase(Ease.Linear);
        }
    }
}

