using TheChecklist.Data;
using TheChecklist.Features.Player.Input;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Player
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private Transform _cameraRotationParent;
        
        private float xRotation;
        private float yRotation;

        private bool _isSlowed;
        private bool _isLocked;
    
        [Inject] private CameraZoom _cameraZoom;
        [Inject] private GeneralSettingsData _settings;
        [Inject] private InputManager _inputManager;
        [Inject] private PlayerInteractable _playerInteractable;
        [Inject] private CameraShaking _cameraShaking; 

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnEnable()
        {
            _inputManager.OnLook += Rotate;
            _playerInteractable.OnInteractionStarted += EnableSlowRotation;
            _playerInteractable.OnInteractionEnded += DisableSlowRotation;

            _cameraShaking.OnStartShaking += LockRotation;
            _cameraShaking.OnEndShaking += UnlockRotation;
        }

        private void OnDisable()
        {
            _inputManager.OnLook -= Rotate;
            _playerInteractable.OnInteractionStarted -= EnableSlowRotation;
            _playerInteractable.OnInteractionEnded -= DisableSlowRotation;
            
            _cameraShaking.OnStartShaking -= LockRotation;
            _cameraShaking.OnEndShaking -= UnlockRotation;
        }

        private void LateUpdate()
        {
            if (_isLocked) return;
            transform.localRotation = Quaternion.Euler(-xRotation, -yRotation, 0);
        }

        private void Rotate(Vector2 delta)
        {
            if (_isLocked) return; 
            
            float mouseX = delta.x * _settings.MouseSensitivity 
                           / (_isSlowed ? _settings.DraggingResistance : _settings.ZeroResistance)
                           * (_cameraZoom.CurrentFOV / _settings.MaxFOV);
            float mouseY = delta.y * _settings.MouseSensitivity 
                           / (_isSlowed ? _settings.DraggingResistance : _settings.ZeroResistance)
                           * (_cameraZoom.CurrentFOV / _settings.MaxFOV);
        
            xRotation += mouseY;
            yRotation -= mouseX;
        
            xRotation = Mathf.Clamp(xRotation, -_settings.XRotationClamp, _settings.XRotationClamp);
        }
        
        private void LockRotation() => _isLocked = true;
        
        private void UnlockRotation() => _isLocked = false;
        
        private void EnableSlowRotation() => _isSlowed = true;
        private void DisableSlowRotation() => _isSlowed = false;
    }
}

