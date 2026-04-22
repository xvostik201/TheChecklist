using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TheChecklist.Core.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Core.Player
{
    public class CameraShaking : MonoBehaviour
    {
        [Inject] private PlayerInteractable  _playerInteractable;
    
        [SerializeField] private float _shakingDuration = 0.5f;
        [SerializeField] private int _vibrationDuration = 5;
        [SerializeField] private float _angle = 10f;
    
        public event Action OnStartShaking;
        public event Action OnEndShaking;

        public void CameraShake()
        {
            OnStartShaking?.Invoke();
    
            transform.DOComplete(); 
    
            transform.DOShakeRotation(_shakingDuration, new Vector3(0, _angle, 0), _vibrationDuration,
                    90, fadeOut: false)
                .OnComplete(() =>
                {
                    OnEndShaking?.Invoke(); 
                });
            
        }
    }
}

