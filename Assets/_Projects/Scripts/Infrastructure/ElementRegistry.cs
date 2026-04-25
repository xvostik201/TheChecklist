using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheChecklist.Core.CockpitElements;

namespace TheChecklist.Infrastructure
{
    public class ElementRegistry
    {
        private readonly Dictionary<string, BaseCockpitElement> _elements = new();

        public void Register(string id, BaseCockpitElement element)
        {
            if (string.IsNullOrEmpty(id)) return;
        
            if (!_elements.ContainsKey(id))
            {
                _elements.Add(id, element);
            }
        }

        public BaseCockpitElement GetElement(string id)
        {
            if (_elements.TryGetValue(id, out var element))
            {
                return element;
            }
            return null;
        }
    }
}

