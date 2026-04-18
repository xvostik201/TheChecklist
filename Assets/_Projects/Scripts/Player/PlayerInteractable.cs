using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInteractable : MonoBehaviour
{
    [SerializeField] private float _interactionRange = 10f;
    [SerializeField] private LayerMask _interactableLayer;

    private Dictionary<Collider, IInteractable> _interactablesCache;

    public event Action OnInteractionStarted;
    public event Action OnInteractionEnded;

    private bool _isDragging;
    private IInteractable _currentInteractable;
    
    [Inject] private InputManager _inputManager;
    [Inject] private Camera _camera;

    private void Awake()
    {
        _interactablesCache = new Dictionary<Collider, IInteractable>();
    }

    private void OnEnable()
    {
        _inputManager.OnLeftMouseClick += OnInteract;
        _inputManager.OnDragEnd += StopDragging;
    }

    private void OnDisable()
    {
        _inputManager.OnLeftMouseClick -= OnInteract;
        _inputManager.OnDragEnd -= StopDragging;
    }

    private void Update()
    {
        if (_isDragging && _currentInteractable != null)
        {
            Vector2 mouseDelta = _inputManager.MouseDelta();

            if (_currentInteractable is Dragging draggingObject)
            {
                draggingObject.UpdateHandlePosition(mouseDelta.y);
            }
        }
    }

    private void OnInteract()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, _interactionRange, _interactableLayer);
        if (hit.collider != null)
        {
            if (!_interactablesCache.TryGetValue(hit.collider, out IInteractable interactable))
            {
                interactable = hit.collider.GetComponent<IInteractable>()
                               ?? hit.collider.GetComponentInParent<IInteractable>();
                
                _interactablesCache[hit.collider] = interactable;
            }

            if (interactable.Data.ElementType == CockpitElementType.Dragging)
            {
                StartDragging(interactable);
            }
            else interactable.OnInteract();
        }
    }

    private void StartDragging(IInteractable interactable)
    {
        _isDragging = true;
        _currentInteractable =  interactable;
        OnInteractionStarted?.Invoke();
        
        _currentInteractable.OnInteract();
    }

    private void StopDragging()
    {
        _isDragging = false;
        _currentInteractable = null;
        OnInteractionEnded?.Invoke();
    }
}
