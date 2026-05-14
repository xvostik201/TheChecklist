using System;
using DG.Tweening;
using UnityEngine;

namespace TheChecklist.Features.Cockpit.Systems
{
    [Serializable]
    public class EngineAudioGroup
    {
        public AudioSource TurbineWhine;
        public AudioSource ExhaustRoar;
        public float CurrentRPM;
        public Tween RpmTween;

        public void KillTween()
        {
            RpmTween?.Kill();
        }
    
        public void SetParameters(float rpmNormalized)
        {
            TurbineWhine.pitch = Mathf.Lerp(0.8f, 1.5f, rpmNormalized);
            ExhaustRoar.volume = Mathf.Lerp(0.0f, 1.0f, rpmNormalized);
        }

        public void Activate(bool activate)
        {
            if (activate)
            {
                TurbineWhine.Play(); 
                ExhaustRoar.Play();
            }
            else
            {
                TurbineWhine.Pause();
                ExhaustRoar.Pause();
            }
        }
    }
}

