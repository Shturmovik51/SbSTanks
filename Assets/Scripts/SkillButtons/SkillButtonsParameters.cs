using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    [System.Serializable]
    public class SkillButtonsParameters
    {
        [SerializeField] ElementType _elementType;
        [SerializeField, TextArea(1,2)] private string _description;
        [SerializeField] private int _coolDown;

        public ElementType ElementType => _elementType;
        public string Description => _description;
        public int CoolDown => _coolDown;
    }
}