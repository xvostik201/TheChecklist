using System;
using TheChecklist.Features.Cockpit.Data;
using TheChecklist.Interfaces;
using UnityEngine;

namespace TheChecklist.Features.Cockpit.Elements.Clipboard
{
    public class ClipboardButton : MonoBehaviour, IInteractable
    {
        public event Action OnClick;
        public void OnInteract()
        {
            OnClick?.Invoke();
        }

        public string GetHoverText()
        {
            return "";
        }

        public CockpitElementData Data { get; }
    }
}

