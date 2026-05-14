using System.Collections;
using System.Collections.Generic;
using TheChecklist.Data;
using TheChecklist.Features.Cockpit.Data;
using UnityEngine;

namespace TheChecklist.Interfaces
{
    public interface IInteractable
    {
        public void OnInteract();

        public string GetHoverText();
        public CockpitElementData Data { get; }
        bool RequiresCheckList => Data != null;
    }
}

