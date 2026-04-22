using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraShaking>().FromComponentInHierarchy().AsSingle();
        }
    }
}

