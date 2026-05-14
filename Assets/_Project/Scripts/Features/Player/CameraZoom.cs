using TheChecklist.Data;
using TheChecklist.Features.Player.Input;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Player
{
    public class CameraZoom : MonoBehaviour
    {
        [Inject] private GeneralSettingsData _settings;
        [Inject] private InputManager _inputManager;
        [Inject] private Camera _mainCamera;

        private float _currentFOV;
        private float _targetFOV;

        public float CurrentFOV => _currentFOV;
        private void Awake()
        {
            _currentFOV = _mainCamera.fieldOfView;
            _targetFOV = _currentFOV;
        }

        private void OnEnable()
        {
            _inputManager.OnScroll +=  UpdateCameraZoom;
        }

        private void OnDisable()
        {
            _inputManager.OnScroll -=  UpdateCameraZoom;
        }

        private void Update()
        {
            _currentFOV = Mathf.Lerp(_currentFOV, _targetFOV, Time.deltaTime * 10f);
            _mainCamera.fieldOfView = _currentFOV;
        }

        private void UpdateCameraZoom(Vector2 delta)
        {
            float zoom = -delta.y * _settings.ZoomSensitivity;
            _targetFOV = Mathf.Clamp(_targetFOV + zoom, _settings.MinFOV, _settings.MaxFOV);
            
        }
    }
}

