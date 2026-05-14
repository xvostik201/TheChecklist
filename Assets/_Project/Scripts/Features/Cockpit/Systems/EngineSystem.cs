using DG.Tweening;
using TheChecklist.Features.Cockpit.Elements;
using TheChecklist.Features.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class EngineSystem : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] protected EngineAudioGroup _rightEngineAudioGroup;
        [SerializeField] protected EngineAudioGroup _leftEngineAudioGroup;
        
        [Header("Engine lever")]
        [SerializeField] private Lever _rightEngine;
        [SerializeField] private Lever _leftEngine;
        [SerializeField] private float _engineRpmDuration = 5f;

        [Inject] private CameraShaking _cameraShaking;
        [Inject] private PowerSystem _powerSystem;
        
        private void OnEnable()
        {
            _rightEngine.OnStateChanged += (state) => HandleEngine(state, _rightEngineAudioGroup);
            _leftEngine.OnStateChanged += (state) => HandleEngine(state, _leftEngineAudioGroup);

            _powerSystem.OnPowerChanged += StopAllEngines;
        }

        private void OnDisable()
        {
            _powerSystem.OnPowerChanged -= StopAllEngines;
        }

        private void HandleEngine(bool state, EngineAudioGroup engineGroup)
        {
            engineGroup.KillTween();    
            
            if (!_powerSystem.IsPowered || !state)
            {
                StopEngine(engineGroup);
                return;
            }

            engineGroup.Activate(true);
    
            engineGroup.RpmTween = DOTween.To(() => engineGroup.CurrentRPM, x => 
            {
                engineGroup.CurrentRPM = x;
                engineGroup.SetParameters(x); 
    
                if (engineGroup == _leftEngineAudioGroup) 
                    _cameraShaking.SetLeftEnginePower(x);
                else 
                    _cameraShaking.SetRightEnginePower(x);

            }, 1f, _engineRpmDuration).SetEase(Ease.InCubic);
        }
        
        
        private void StopEngine(EngineAudioGroup engineGroup)
        {
            engineGroup.KillTween();
            engineGroup.RpmTween = DOTween.To(() => engineGroup.CurrentRPM, x => 
            {
                engineGroup.CurrentRPM = x;
                engineGroup.SetParameters(x);
            }, 0f, _engineRpmDuration / 2).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                if(engineGroup.CurrentRPM <= 0.02f)
                    engineGroup.Activate(false);
            });
        }

        private void StopAllEngines(bool isPowered)
        {
            if (isPowered) return;
            
            StopEngine(_rightEngineAudioGroup);
            StopEngine(_leftEngineAudioGroup);
        }
    }
}

