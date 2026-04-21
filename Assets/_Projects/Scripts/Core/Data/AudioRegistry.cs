using System.Collections;
using System.Collections.Generic;
using TheChecklist.Data;
using UnityEngine;

namespace TheChecklist.Data
{
    [CreateAssetMenu(fileName = "AudioRegistry", menuName = "ScriptableObjects/Data/AudioRegistry")]
    public class AudioRegistry : ScriptableObject
    {
        [SerializeField] private List<AudioClipData> audioClips = new List<AudioClipData>();

        public AudioClip GetAudioClip(string id)
        {
            var data = audioClips.Find(x => x.AudioSourceID == id);

            if (data == null)
            {
                Debug.LogWarning($"[AudioRegistry] Sound with ID: '{id}' dont exist!");
                return null;
            }
        
            return data.AudioClip;
        }
    }
}

