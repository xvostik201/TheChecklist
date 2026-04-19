using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Input;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

