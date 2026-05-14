using TheChecklist.Features.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraShaking>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraZoom>().FromComponentInHierarchy().AsSingle();
        }
    }
}

