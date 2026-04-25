using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Services;
using TheChecklist.Data;
using TheChecklist.Interfaces;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioRegistry _audioRegistry;
    public override void InstallBindings()
    {
        Container.BindInstance(_audioRegistry).AsSingle();
        
        Container.Bind<IAudioProvider>()
            .To<UnityAudioService>()
            .FromComponentInHierarchy()
            .AsSingle();
    }    
}
