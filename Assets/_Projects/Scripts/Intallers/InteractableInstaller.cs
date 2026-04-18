using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractableInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInteractable>().FromComponentInHierarchy().AsSingle();
    }
}
