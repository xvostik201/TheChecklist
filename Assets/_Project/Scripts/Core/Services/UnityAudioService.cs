using System.Collections.Generic;
using TheChecklist.Data;
using TheChecklist.Interfaces;
using UnityEngine;
using Zenject;

namespace TheChecklist.Core.Services
{
    public class UnityAudioService : MonoBehaviour, IAudioProvider
    {
        [SerializeField] private AudioSource _audioSourcePrefab;
        [SerializeField] private int _poolSize = 10;

        readonly List<AudioSource> _audioSourcePool = new List<AudioSource>();
        readonly float _baseAudioSourcePitch = 1f;

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
            var currentSource = SetupCurrentAudioSource(audioID, true);
            
            currentSource.Play();
            currentSource.transform.position = soundPosition;
        }

        public void PlaySound2D(string audioID)
        {
            var currentSource = SetupCurrentAudioSource(audioID);

            currentSource.Play();
        }

        private AudioSource SetupCurrentAudioSource(string audioID, bool is3DSound = false)
        {
            var clip = _audioRegistry.GetAudioClip(audioID);
            var volume = _audioRegistry.GetAudioClipVolume(audioID);
            
            AudioSource currentSource = GetAudioSource();
            
            currentSource.gameObject.SetActive(true);
            
            currentSource.clip = clip;
            currentSource.spatialBlend = is3DSound ? 1f : 0f;
            currentSource.volume = volume * Random.Range(0.9f, 1.1f);
            currentSource.pitch = _baseAudioSourcePitch * Random.Range(0.8f, 1.2f);
            
            return currentSource;
        }
    }
}

