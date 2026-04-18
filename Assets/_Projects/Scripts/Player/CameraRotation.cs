using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    [Inject] private GeneralSettingsData _settings;
    
    private float xRotation;
    private float yRotation;

    private bool _isLocked;
    
    [Inject] private InputManager _inputManager;
    [Inject] private PlayerInteractable _playerInteractable;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _inputManager.OnLook += Rotate;
        _playerInteractable.OnInteractionStarted += LockRotation;
        _playerInteractable.OnInteractionEnded += UnlockRotation;
    }

    private void OnDisable()
    {
        _inputManager.OnLook -= Rotate;
        _playerInteractable.OnInteractionStarted -= LockRotation;
        _playerInteractable.OnInteractionEnded -= UnlockRotation;
    }

    private void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(-xRotation, -yRotation, 0);
    }

    private void Rotate(Vector2 delta)
    {
        float mouseX = delta.x * _settings.MouseSensitivity 
                       / (_isLocked ? _settings.DraggingResistance : _settings.ZeroResistance);
        float mouseY = delta.y * _settings.MouseSensitivity 
                       / (_isLocked ? _settings.DraggingResistance : _settings.ZeroResistance);
        
        xRotation += mouseY;
        yRotation -= mouseX;
        
        xRotation = Mathf.Clamp(xRotation, -_settings.XRotationClamp, _settings.XRotationClamp);
    }

    private void LockRotation() => _isLocked = true;
    private void UnlockRotation() => _isLocked = false;
}
