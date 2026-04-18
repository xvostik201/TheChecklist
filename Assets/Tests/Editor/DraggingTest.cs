using NUnit.Framework;
using UnityEngine;

public class DraggingTest
{
    [Test]
    public void Dragging_ShouldReturnCorrentNormalizedValue()
    {
        var testData = ScriptableObject.CreateInstance<CockpitElementData>();

        float min = 0f;
        float max = 100f;
        float current = 63f;
        
        float result = Mathf.InverseLerp(min, max, current);
        
        Assert.AreEqual(0.63f, result, "NormalizedValue");
    }
}
