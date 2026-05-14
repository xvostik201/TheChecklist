using System.Collections.Generic;
using TheChecklist.Features.Checklist;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure.Installers
{
    public class ChecklistInstaller : MonoInstaller
    {
        [SerializeField] private List<ChecklistStep> _checklistSteps;

        public override void InstallBindings()
        {
            Container.BindInstance(_checklistSteps).AsSingle();
        
            Container.BindInterfacesAndSelfTo<ChecklistManager>().AsSingle();
        }
    }

}
