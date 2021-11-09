using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    public class SkillButton
    {
        public Button Button { get; }
        public string Description { get; }
        public TextMeshProUGUI TextField { get; }
        public int MaxCD { get; }
        public ElementType ElementType { get; }
        public int CurrentCD { get; set; }
        public bool IsActive { get; set; }

        public SkillButton(Button button, int maxCD, string description, ElementType elementType)
        {
            Button = button;
            TextField = button.GetComponentInChildren<TextMeshProUGUI>();
            MaxCD = maxCD;
            Description = description;
            ElementType = elementType;
            TextField.text = description;
        }
    }
}