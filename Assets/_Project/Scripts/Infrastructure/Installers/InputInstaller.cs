using TheChecklist.Features.Player.Input;
using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

