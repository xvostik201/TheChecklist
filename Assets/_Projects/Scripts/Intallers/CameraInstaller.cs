using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
    }
}
