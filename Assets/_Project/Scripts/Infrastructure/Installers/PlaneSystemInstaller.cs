using TheChecklist.Features.Cockpit.Systems;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class PlaneSystemInstaller : MonoInstaller
    {
        [SerializeField] private PowerSystem _powerSystem;
        [SerializeField] private EngineSystem _engineSystem;
        [SerializeField] private CanopySystem _canopySystem;
        [SerializeField] private BrakeSystem _brakeSystem;
        [SerializeField] private RadarSystem _radarSystem;
        [SerializeField] private TakeoffSequence _takeoffSequence;
        public override void InstallBindings()
        {
            Container.BindInstance(_powerSystem).AsSingle();
            Container.BindInstance(_engineSystem).AsSingle();
            Container.BindInstance(_canopySystem).AsSingle();
            Container.BindInstance(_brakeSystem).AsSingle();
            Container.BindInstance(_radarSystem).AsSingle();
            Container.BindInstance(_takeoffSequence).AsSingle();
        }
    }
}

