using System;

namespace TheChecklist.Interfaces
{
    public interface IToggleableElement
    {
        bool IsActive { get; }
    
        event Action<bool> OnStateChanged;
    }
}

