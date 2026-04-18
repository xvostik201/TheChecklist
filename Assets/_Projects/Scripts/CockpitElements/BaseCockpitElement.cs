using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseCockpitElement : MonoBehaviour, IInteractable
{
    [SerializeField] protected string _elementID;

    protected bool _isActive = false;

    [Inject] protected ElementRegistry _elementRegistry;
    protected CockpitElementData _data;

    protected virtual void Start()
    {
        if(!_elementRegistry.GetElementData(_elementID))
            Debug.LogWarning($"[Cockpit] Data missing for ID: {_elementID} on object {name}. Interaction disabled.");
        else
        {
            _data = _elementRegistry.GetElementData(_elementID);
        }
    }
    public abstract void OnInteract();

    public string GetHoverText() => _data != null ? _data.ElementName : "Unknow element";
    public CockpitElementData Data => _data;

}
