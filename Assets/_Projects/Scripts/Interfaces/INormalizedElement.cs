using System;


public interface INormalizedElement
{
    float NormalizedValue { get; }
    event Action<float> OnValueChanged;
}
