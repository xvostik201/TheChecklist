using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementRegistry", menuName = "ScriptableObjects/Registry/ElementRegistry")]
public class ElementRegistry : ScriptableObject
{
    public List<CockpitElementData> AllElement;
    
    public CockpitElementData GetElementData(string elementID)
        => AllElement.Find(x => x.ElementID == elementID);
}
