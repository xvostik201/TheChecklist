using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core;
using TheChecklist.Core.Data;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
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
