using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class ElementInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ElementRegistry>().AsSingle();
        }
    }
}

