namespace TheChecklist.Features.Aircraft.F4Phantom
{
    public class F4_Phantom : PlaneBase
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _checklistManager.OnChecklistComplete += _takeoffSequence.PlayCatapultGForce;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _checklistManager.OnChecklistComplete -= _takeoffSequence.PlayCatapultGForce;
        }
    }
}

