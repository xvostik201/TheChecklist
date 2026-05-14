using TheChecklist.Features.Cockpit.Elements;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class BrakeSystem : MonoBehaviour
    {
        [Header("Brakes button")]
        [SerializeField] private Button _brakesButton;
        [SerializeField] private Material _brakesButtonMaterial;
        
        [Inject] private PowerSystem _powerSystem;

        private void Awake() => UpdateVisuals(false);

        private void OnEnable()
        {
            _brakesButton.OnStateChanged += HandleBrakeChange;
            _powerSystem.OnPowerChanged += HandlePowerChange;
        }

        private void OnDisable()
        {
            _brakesButton.OnStateChanged -= HandleBrakeChange;
            _powerSystem.OnPowerChanged -= HandlePowerChange;
        }

        private void HandlePowerChange(bool isPowered)
        {
            if (!isPowered && _brakesButton.IsActive)
            {
                UpdateVisuals(false);
            }
        }

        private void HandleBrakeChange(bool state)
        {
            bool shouldLightUp = state && _powerSystem.IsPowered;
            UpdateVisuals(shouldLightUp);
        }
        
        private void UpdateVisuals(bool isOn)
        {
            if (isOn)
            {
                _brakesButtonMaterial.EnableKeyword("_EMISSION");
                _brakesButtonMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            }
            else
            {
                _brakesButtonMaterial.DisableKeyword("_EMISSION");
                _brakesButtonMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack; 
            }
        }
    }
}