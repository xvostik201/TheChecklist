using System;
using TheChecklist.Features.Cockpit.Elements;
using UnityEngine;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class PowerSystem : MonoBehaviour
    {
        [Header("Power button")]
        [SerializeField] private Button _powerButton;
        [SerializeField] private Material _powerButtonMaterial;

        public event Action<bool> OnPowerChanged;
        public bool IsPowered { get; private set; }

        private void Awake()
        {
            UpdateButtonVisuals(false);
        }

        private void OnEnable()
        {
            _powerButton.OnStateChanged += HandlePowerSwitch;
        }

        private void OnDisable()
        {
            _powerButton.OnStateChanged -= HandlePowerSwitch;
        }

        private void HandlePowerSwitch(bool state)
        {
            IsPowered = state;
            UpdateButtonVisuals(state);
            OnPowerChanged?.Invoke(state);
        }

        private void UpdateButtonVisuals(bool powered)
        {
            if (powered)
            {
                _powerButtonMaterial.EnableKeyword("_EMISSION");
                _powerButtonMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            }
            else
            {
                _powerButtonMaterial.DisableKeyword("_EMISSION");
                _powerButtonMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            }
        }
    }
}