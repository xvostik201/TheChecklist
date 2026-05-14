using DG.Tweening;
using TheChecklist.Features.Cockpit.Elements;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class RadarSystem : MonoBehaviour
    {
        [Header("RLS")]
        [SerializeField] private Lever _rlsLever;
        [SerializeField] private Material _rlsMaterial;
        [SerializeField] private Color _rlsBaseColor;
        
        private Tween _rlsTween;
        private float _currentRlsIntensity;
        
        [Inject] private PowerSystem _powerSystem;

        private void Awake() => SetMaterialIntensity(0f, 0f);

        private void OnEnable()
        {
            _rlsLever.OnStateChanged += HandleRlsChange;
            _powerSystem.OnPowerChanged += HandlePowerChange;
        }

        private void OnDisable()
        {
            _rlsLever.OnStateChanged -= HandleRlsChange;
            _powerSystem.OnPowerChanged -= HandlePowerChange;
        }

        private void HandlePowerChange(bool isPowered)
        {
            if (!isPowered && _rlsLever.IsActive)
            {
                SetMaterialIntensity(0f, 0.5f);
            }
        }

        private void HandleRlsChange(bool state)
        {
            if (_powerSystem.IsPowered && state)
            {
                SetMaterialIntensity(4f);
            }
            else
            {
                SetMaterialIntensity(0f);
            }
        }
    
        private void SetMaterialIntensity(float targetIntensity, float duration = 2f)
        {
            _rlsTween?.Kill();
            _rlsTween = DOTween.To(() => _currentRlsIntensity, x =>
            {
                _currentRlsIntensity = x;
                _rlsMaterial.SetColor("_EmissionColor", _rlsBaseColor * _currentRlsIntensity);
            }, targetIntensity, duration).SetEase(Ease.OutQuad);
        }
    }
}