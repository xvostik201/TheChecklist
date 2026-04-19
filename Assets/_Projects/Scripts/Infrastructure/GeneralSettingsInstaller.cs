using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Data;
using UnityEngine;
using Zenject;

namespace TheChecklist.Infrastructure
{
    public class GeneralSettingsInstaller : MonoInstaller
    {
        [SerializeField] private GeneralSettingsData _generalSettingsData;

        public override void InstallBindings()
        {
            Container.BindInstance(_generalSettingsData);
        }
    }
}

