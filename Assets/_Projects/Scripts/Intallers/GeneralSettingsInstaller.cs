using System.Collections;
using System.Collections.Generic;
using TheChecklist.Data;
using UnityEngine;
using Zenject;

namespace TheChecklist.Installers
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

