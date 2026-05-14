using DG.Tweening;
using TheChecklist.Features.Cockpit.Elements;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class CanopySystem : MonoBehaviour
    {
        [Header("Cockpit Glass")]
        [SerializeField] private Button _cockpitGlassButton;
        [SerializeField] private Material _cockpitGlassMaterial;
        [SerializeField] private Transform _cockpitGlassTransform;
        [SerializeField] private Vector3 _targetCockpitGlassAngle;
        [SerializeField] private float _glassAnimationDuration = 0.5f;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private float _cutOffTrue = 5000f;
        [SerializeField] private float _cutOffFalse = 11000f;
        private float _currentMixerCutOff;
        private Vector3 _startLocalRotation;
        private const string CockpitCutoffParam = "CockpitCutoffFreq";
        
        [Inject] private PowerSystem _powerSystem;
    
        private void Awake()
        {
            _startLocalRotation = _cockpitGlassTransform.localRotation.eulerAngles;
            _currentMixerCutOff = _cutOffFalse;
            
            _cockpitGlassMaterial.DisableKeyword("_EMISSION");
            _cockpitGlassMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        }
    
        private void OnEnable()
        {
            _cockpitGlassButton.OnStateChanged += OnCockpitStateChanged;
        }
    
        private void OnDisable()
        {
            _cockpitGlassButton.OnStateChanged -= OnCockpitStateChanged;
        }
        
        private void OnCockpitStateChanged(bool state)
        {
            Quaternion targetRotation = state 
                ? Quaternion.Euler(_targetCockpitGlassAngle) 
                : Quaternion.Euler(_startLocalRotation);
    
            _cockpitGlassTransform.DOLocalRotateQuaternion(targetRotation, _glassAnimationDuration);
                
            if (state)
            {
                _cockpitGlassMaterial.EnableKeyword("_EMISSION");
                _cockpitGlassMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                    
                DOTween.To(() => _currentMixerCutOff, x =>
                {
                    _currentMixerCutOff = x;
                    _audioMixer.SetFloat(CockpitCutoffParam, _currentMixerCutOff);
                }, _cutOffTrue, _glassAnimationDuration).SetEase(Ease.OutQuad);
            }
            else
            {
                _cockpitGlassMaterial.DisableKeyword("_EMISSION");
                _cockpitGlassMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack; 
                    
                DOTween.To(() => _currentMixerCutOff, x =>
                {
                    _currentMixerCutOff = x;
                    _audioMixer.SetFloat(CockpitCutoffParam, _currentMixerCutOff);
                }, _cutOffFalse, _glassAnimationDuration).SetEase(Ease.OutQuad);
            }
        }
    }
}

