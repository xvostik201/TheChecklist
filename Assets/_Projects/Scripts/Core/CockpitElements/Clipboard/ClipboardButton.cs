using System;
using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Data;
using TheChecklist.Interfaces;
using UnityEngine;

namespace TheChecklist.Core.Clipboard
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

