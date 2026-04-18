using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GeneralSettingsInstaller : MonoInstaller
{
   [SerializeField] private GeneralSettingsData _generalSettingsData;

   public override void InstallBindings()
   {
      Container.BindInstance(_generalSettingsData);
   }
}
