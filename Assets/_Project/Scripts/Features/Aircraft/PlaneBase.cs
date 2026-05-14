using TheChecklist.Features.Checklist;
using TheChecklist.Features.Cockpit.Systems;
using TheChecklist.Features.Player;
using UnityEngine;
using Zenject;

namespace TheChecklist.Features.Aircraft
{
    public abstract class PlaneBase : MonoBehaviour
    {
        [Inject] protected PowerSystem _powerSystem;
        [Inject] protected EngineSystem _engineSystem;
        [Inject] protected CanopySystem _canopySystem;
        [Inject] protected BrakeSystem _brakeSystem;
        [Inject] protected RadarSystem _radarSystem;
        [Inject] protected TakeoffSequence _takeoffSequence;
        [Inject] protected CameraShaking _cameraShaking;
        [Inject] protected ChecklistManager _checklistManager;
        protected virtual void Awake()
        {
            
        }
        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }
    }
}


