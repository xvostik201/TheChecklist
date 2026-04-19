using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
{
    public class InteractableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInteractable>().FromComponentInHierarchy().AsSingle();
        }
    }
}

