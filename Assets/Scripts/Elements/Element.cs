using System;
using UnityEngine;

namespace SbSTanks
{
    public class Element : IElement
    {
        public ElementType EntityElement { get; private set; }
        public bool IsActive { get; private set; }

        public Element()
        {
            UpdateElement();
        }

        public void UpdateElement()
        {
            var values = Enum.GetValues(typeof(ElementType));
            EntityElement = (ElementType)UnityEngine.Random.Range(0, values.Length);
        }

        public void SetElementType(ElementType elementType)
        {
            EntityElement = elementType;
            IsActive = true;
        }

        public void DeactivateElement()
        {
            IsActive = false;
        }
    }
}