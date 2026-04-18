using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ElementInstaller : MonoInstaller
{
    [SerializeField] private ElementRegistry _elementRegistry;
    public override void InstallBindings()
    {
        Container.BindInstance(_elementRegistry);
    }
}
