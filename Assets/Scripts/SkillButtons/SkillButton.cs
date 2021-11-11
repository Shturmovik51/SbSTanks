using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SbSTanks
{
    public class SkillButton
    {
        public Button Button { get; }
        public Image CDImage { get; }
        public string Description { get; }
        public TextMeshProUGUI TextField { get; }
        public TextMeshProUGUI CDText { get; }
        public int MaxCD { get; }
        public ElementType ElementType { get; }
        public int CurrentCD { get; set; }
        public bool IsActive { get; set; }

        public SkillButton(Button button, Image cDImage, int maxCD, string description, ElementType elementType, TextMeshProUGUI cDText)
        {
            Button = button;
            CDImage = cDImage;
            TextField = button.GetComponentInChildren<TextMeshProUGUI>();
            CDText = cDText;
            MaxCD = maxCD;
            CurrentCD = maxCD;
            Description = description;
            ElementType = elementType;
            TextField.text = description;
        }
    }
}