using System;
using System.Collections.Generic;
using TheChecklist.Data;
using TheChecklist.Interface;
using UnityEngine;
using Zenject;

namespace TheChecklist.Core.Services
{
    public class UnityAudioService : MonoBehaviour, IAudioProvider
    {
        [SerializeField] private AudioSource _audioSourcePrefab;
        [SerializeField] private int _poolSize = 10;

        readonly List<AudioSource> _audioSourcePool = new List<AudioSource>();

        [Inject] private AudioRegistry _audioRegistry;

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                AudioSource source = Instantiate(_audioSourcePrefab, transform);
                source.gameObject.SetActive(false);
                _audioSourcePool.Add(source);
            }
        }

        private AudioSource GetAudioSource()
        {
            for (int i = 0; i < _audioSourcePool.Count; i++)
            {
                if(!_audioSourcePool[i].isPlaying) 
                    return  _audioSourcePool[i];
            }

            return null;
        }

        public void PlaySound3D(Vector3 soundPosition, string audioID)
        {
            var clip = _audioRegistry.GetAudioClip(audioID);
            var pos = soundPosition;
            
            AudioSource currentSource = GetAudioSource();
            
            currentSource.gameObject.SetActive(true);
            
            currentSource.clip = clip;
            currentSource.transform.position = pos;
            currentSource.spatialBlend = 1f;
            
            currentSource.Play();
        }

        public void PlaySound2D(string audioID)
        {
            
        }
    }
}

