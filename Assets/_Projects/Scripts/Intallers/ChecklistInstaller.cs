using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChecklistInstaller : MonoInstaller
{
    [SerializeField] private List<ChecklistStep> _checklistSteps;

    public override void InstallBindings()
    {
        Container.BindInstance(_checklistSteps).AsSingle();
        
        Container.BindInterfacesAndSelfTo<ChecklistManager>().AsSingle();
    }
}
