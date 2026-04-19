using System.Collections;
using System.Collections.Generic;
using TheChecklist.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Installers
{
    public class InteractableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInteractable>().FromComponentInHierarchy().AsSingle();
        }
    }
}

