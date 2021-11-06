using System;

namespace SbSTanks
{
    public class Element : IElement
    {
        public ElementType EntityElement { get; private set; }

        public Element()
        {
            UpdateElement();
        }

        public void UpdateElement()
        {
            var values = Enum.GetValues(typeof(ElementType));
            EntityElement = (ElementType)UnityEngine.Random.Range(0, values.Length);
        }
    }
}