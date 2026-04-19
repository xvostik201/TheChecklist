using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseCockpitElement : MonoBehaviour, IInteractable
{
    [SerializeField] protected CockpitElementData _elementData;

    protected bool _isActive = false;

    [Inject] protected ElementRegistry _elementRegistry;

    protected virtual void Awake()
    {
        if(_elementData !=null) _elementRegistry.Register(_elementData.ElementID, this);
    }
    public abstract void OnInteract();

    public string GetHoverText() => _elementData != null ? _elementData.ElementName : "Unknow element";
    public CockpitElementData Data => _elementData;

}
