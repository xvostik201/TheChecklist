using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Player
{
    public class CameraShaking : MonoBehaviour
    {
        [Inject] private PlayerInteractable  _playerInteractable;
    
        [SerializeField] private float _shakingDuration = 0.5f;
        [SerializeField] private int _vibrationDuration = 5;
        [SerializeField] private float _angle = 10f;
    
        public event Action OnStartShaking;
        public event Action OnEndShaking;

        [Header("Engine Shake Settings")]
        [SerializeField] private float _maxContinuousAngle = 2f;
        [SerializeField] private float _shakeSpeed = 15f;
        [SerializeField] private Transform _camParent;
        
        private float _leftEnginePower;
        private float _rightEnginePower;
        private Vector3 _initialLocalRotation;

        private void Start()
        {
            _initialLocalRotation = _camParent.localEulerAngles;
        }

        public void CameraShake()
        {
            OnStartShaking?.Invoke();
    
            transform.DOComplete(); 
    
            transform.DOShakeRotation(_shakingDuration, new Vector3(0, _angle, 0), _vibrationDuration
                    , 0, fadeOut: false)
                .OnComplete(() =>
                {
                    OnEndShaking?.Invoke(); 
                });
        }

        public void SetLeftEnginePower(float rpm) => _leftEnginePower = rpm * 0.5f;
        public void SetRightEnginePower(float rpm) => _rightEnginePower = rpm * 0.5f;

        private void Update()
        {
            float totalIntensity = _leftEnginePower + _rightEnginePower;

            if (totalIntensity > 0.05f)
            {
                float shakeX = (Mathf.PerlinNoise(Time.time * _shakeSpeed, 0) - 0.5f) * 2f;
                float shakeY = (Mathf.PerlinNoise(0, Time.time * _shakeSpeed) - 0.5f) * 2f;
                float shakeZ = (Mathf.PerlinNoise(Time.time * _shakeSpeed, Time.time * _shakeSpeed) - 0.5f) * 2f;

                Vector3 targetShake = new Vector3(shakeX, shakeY, shakeZ) * _maxContinuousAngle * totalIntensity;
                
                if (!DOTween.IsTweening(transform))
                {
                    _camParent.localEulerAngles = _initialLocalRotation + targetShake;
                }
            }
            else if (!DOTween.IsTweening(transform))
            {
                _camParent.localRotation = Quaternion.Slerp(_camParent.localRotation, Quaternion.Euler(_initialLocalRotation), Time.deltaTime * 5f);
            }
        }
    }
}