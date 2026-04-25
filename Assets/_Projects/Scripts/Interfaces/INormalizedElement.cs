using System;

namespace TheChecklist.Interfaces
{
    public interface INormalizedElement
    {
        float NormalizedValue { get; }
        event Action<float> OnValueChanged;
    }
}

