using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
{
    public class ElementInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ElementRegistry>().AsSingle();
        }
    }
}

