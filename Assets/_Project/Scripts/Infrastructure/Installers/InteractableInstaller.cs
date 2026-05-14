using TheChecklist.Features.Player;
using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class InteractableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInteractable>().FromComponentInHierarchy().AsSingle();
        }
    }
}

