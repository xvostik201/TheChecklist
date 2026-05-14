using TheChecklist.Data;
using TheChecklist.Features.Cockpit.Data;
using TheChecklist.Infrastructure;
using TheChecklist.Interfaces;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Cockpit.Elements
{
    public abstract class BaseCockpitElement : MonoBehaviour, IInteractable
    {
        [SerializeField] protected CockpitElementData _elementData;

        protected bool _isActive = false;
        
        [Inject] protected ElementRegistry _elementRegistry;
        [Inject] protected IAudioProvider _audioProvider;

        protected virtual void Awake()
        {
            if(_elementData !=null) _elementRegistry.Register(_elementData.ElementID, this);
        }
        public abstract void OnInteract();

        public string GetHoverText() => _elementData != null ? _elementData.ElementName : "Unknow element";
        public CockpitElementData Data => _elementData;

    }
}

