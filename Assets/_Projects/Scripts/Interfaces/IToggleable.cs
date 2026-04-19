using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheChecklist.Installers
{
    public interface IToggleable
    {
        bool IsActive { get; }
    
        event Action<bool> OnStateChanged;
    }
}

