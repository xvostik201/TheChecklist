using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheChecklist.Data
{
    [CreateAssetMenu(fileName = "AudioClipData", menuName = "ScriptableObjects/Data/AudioClipData")]
    public class AudioClipData : ScriptableObject
    {
        [SerializeField] private string _audioSourceID = "Toggle";
        public string AudioSourceID =>  _audioSourceID;
    
        [SerializeField] private AudioClip _audioClip;
        public AudioClip AudioClip =>  _audioClip;
    
        [SerializeField] private float _volume = 0.6f;
        public float Volume => _volume;
    }
}

