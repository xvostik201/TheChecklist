using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TheChecklist.Installers;

namespace TheChecklist.Core.CockpitElements
{
    public class Button : BaseCockpitElement, IToggleableElement
    {
        private Vector3 _startLocalPositon;
        private Vector3 _targetLocalPositon;
    
        public bool IsActive => _isActive;
        public event Action<bool> OnStateChanged;

        protected override void Awake()
        {
            base.Awake();
            _startLocalPositon = transform.localPosition;
            if(_elementData != null)  _targetLocalPositon = _elementData.TargetPosition;
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
            Vector3 finalPositionZ = _isActive ? _targetLocalPositon : _startLocalPositon;

            transform.DOLocalMove(finalPositionZ,  _elementData.AnimationDuration).SetEase(Ease.Linear);
        }
    }
}

