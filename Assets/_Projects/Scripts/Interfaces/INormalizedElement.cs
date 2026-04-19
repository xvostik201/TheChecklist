using System;

namespace TheChecklist.Installers
{
    public interface INormalizedElement
    {
        float NormalizedValue { get; }
        event Action<float> OnValueChanged;
    }
}

