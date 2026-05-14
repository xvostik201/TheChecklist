using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheChecklist.Features.Player.Input
{
    public class InputManager : MonoBehaviour
    {
        private GeneralMap _generalMap;

        public event Action<Vector2> OnLook;
        public event Action OnLeftMouseClick;
        public event Action<Vector2> OnScroll;

        public event Action OnDragEnd;

        private void Awake()
        {
            _generalMap = new GeneralMap();
        }

        private void OnEnable()
        {
            _generalMap.Enable();
            _generalMap.Player.Look.performed += OnLookPerformed;
        
            _generalMap.Player.LeftMouse.performed += OnLeftMouseClickPerformed;
        
            _generalMap.Player.LeftMouse.canceled += OnDragCanceled;
            
            _generalMap.Player.MouseScroll.performed += OnScrollPerformed;
        }

        private void OnDisable()
        {
            _generalMap.Disable();
            _generalMap.Player.Look.performed -= OnLookPerformed;
        
            _generalMap.Player.LeftMouse.performed -= OnLeftMouseClickPerformed;
        
            _generalMap.Player.LeftMouse.canceled -= OnDragCanceled;
            
            _generalMap.Player.MouseScroll.performed -= OnScrollPerformed;
        }

        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            Vector2 inputDelta = context.ReadValue<Vector2>();
            OnLook?.Invoke(inputDelta);
        }

        private void OnLeftMouseClickPerformed(InputAction.CallbackContext context)
        {
            OnLeftMouseClick?.Invoke();
        }
    
        private void OnDragCanceled(InputAction.CallbackContext context)
        {
            OnDragEnd?.Invoke();
        }

        private void OnScrollPerformed(InputAction.CallbackContext context)
        {
            OnScroll?.Invoke(context.ReadValue<Vector2>());
        }
    
        public Vector2 MouseDelta() => _generalMap.Player.Look.ReadValue<Vector2>();
    }
}

