using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SbSTanks
{
    [System.Serializable]
    public struct SkillButtonObjects
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _cDImage;
        [SerializeField] private TextMeshProUGUI _cDText;

        public Button Button => _button;
        public Image CDImage => _cDImage;
        public TextMeshProUGUI CDText => _cDText;
    }
}